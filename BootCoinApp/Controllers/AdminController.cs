using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace BootCoinApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IActivenessRepository _activenessRepository;

        public AdminController(UserManager<AppUser> userManager, IUserRepository userRepository, ITransactionRepository transactionRepository, IGroupRepository groupRepository, IEventRepository eventRepository, IActivenessRepository activenessRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
            _groupRepository = groupRepository;
            _eventRepository = eventRepository;
            _activenessRepository = activenessRepository;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> Input(string search, string sortTypes)
        {
            ViewData["FailedInput"] = TempData["FailedInput"];
            ViewData["SuccessInput"] = TempData["SuccessInput"];
            string id = _userManager.GetUserId(User);
            IEnumerable<AppUser> users;
            if (String.IsNullOrEmpty(sortTypes))
            {
                if (TempData["SortData"] == null)
                {
                    sortTypes = "GroupId";
                }
                else
                {
                    sortTypes = TempData["SortData"].ToString();
                }
            }
            if (String.IsNullOrEmpty(search) && TempData["SearchData"] == null)
            {
                users = await _userRepository.GetAllInternExceptIdAsync(id, sortTypes);
            }
            else
            {
                if (TempData["SearchData"] != null)
                {
                    search = TempData["SearchData"].ToString();
                }
                users = await _userRepository.SearchInternExceptIdAsync(id, search, sortTypes);
                ViewData["SearchQuery"] = search;
            }
            AppUser CurrentUser = await _userRepository.GetByIdAsync(id);
            IEnumerable<Group> groups = await _groupRepository.GetAll();
            IEnumerable<Event> events = await _eventRepository.GetAll();
            IEnumerable<Activeness> activenesses = await _activenessRepository.GetAll();
            var model = new InputViewModel
            {
                currentUser = CurrentUser,
                users = users,
                usersCount = users.Count(),
                groups = groups,
                events = events,
                activenesses = activenesses,
            };
            ViewData["SortQuery"] = sortTypes;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> InputCoinPerUser(InputFormViewModel model, string search, string sortTypes)
        {
            if (!String.IsNullOrEmpty(search))
            {
                TempData["SearchData"] = search;
            }
            if (!String.IsNullOrEmpty(sortTypes))
            {
                TempData["SortData"] = sortTypes;
            }
            string id = _userManager.GetUserId(User);
            Transaction transaction = new Transaction
            {
                UserId = id,
                ReceiverId = model.receiverId,
                Date = DateTime.Today,
                amount = model.amount,
                EventId = Int32.Parse(model.eventId),
                ActivenessId = Int32.Parse(model.activenessId),
            };
            var Transactionsuccess = _transactionRepository.Add(transaction);
            var Updateresult = false;
            if (Transactionsuccess) 
            {
                AppUser Receiver = await _userRepository.GetByIdAsync(model.receiverId);
                Receiver.BootCoin += model.amount;
                Updateresult = _userRepository.Update(Receiver);
                if (!Updateresult)
                {
                    Transaction delete = await _transactionRepository.GetLatestTransactionByIdAsync(model.receiverId);
                    var DeleteResult = _transactionRepository.Delete(delete);
                }
            }
            if(Transactionsuccess && Updateresult)
            {
                TempData["SuccessInput"] = "Input Success, Data Updated!";
            }
            else
            {
                TempData["FailedInput"] = "Failed to Input Bootcoin Transaction";
            }
            return Redirect("Input");
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> InputCoinPerGroup(InputFormGroupViewModel model, string search, string sortTypes)
        {
            if (!String.IsNullOrEmpty(search))
            {
                TempData["SearchData"] = search;
            }
            if (!String.IsNullOrEmpty(sortTypes))
            {
                TempData["SortData"] = sortTypes;
            }
            int groupId = Int32.Parse(model.groupId);
            string id = _userManager.GetUserId(User);
            Group group = await _groupRepository.GetByIdAsync(groupId);
            StringBuilder sbSuccess = new StringBuilder();
            StringBuilder sbFailed = new StringBuilder();
            sbSuccess.Append("Input Success, List of Data Updated: <ul> ");
            sbFailed.Append("Input Failed, List of Transaction Failed: <ul> ");
            var allSuccess = true;
            var allFailed = true;
            foreach(var receiver in group.users)
            {
                Transaction transaction = new Transaction
                {
                    UserId = id,
                    ReceiverId = receiver.Id,
                    Date = DateTime.Today,
                    amount = model.amount,
                    EventId = Int32.Parse(model.eventId),
                    ActivenessId = Int32.Parse(model.activenessId),
                };
                var Transactionsuccess = _transactionRepository.Add(transaction);
                var Updateresult = false;
                if (Transactionsuccess)
                {
                    AppUser ReceiverUpdate = await _userRepository.GetByIdAsync(receiver.Id);
                    ReceiverUpdate.BootCoin += model.amount;
                    Updateresult = _userRepository.Update(ReceiverUpdate);
                    if (!Updateresult)
                    {
                        Transaction delete = await _transactionRepository.GetLatestTransactionByIdAsync(receiver.Id);
                        var DeleteResult = _transactionRepository.Delete(delete);
                    }
                }
                if(Transactionsuccess && Updateresult)
                {
                    allFailed = false;
                    sbSuccess.Append(" <li> ");
                    sbSuccess.Append(receiver.FullName);
                    sbSuccess.Append(" </li> ");
                }
                else
                {
                    allSuccess = false;
                    sbFailed.Append(" <li> ");
                    sbFailed.Append(receiver.FullName);
                    sbFailed.Append(" </li> ");
                }
            }
            sbFailed.Append(" </ul>");
            sbSuccess.Append(" </ul>");
            if(allSuccess)
            {
                TempData["SuccessInput"] = sbSuccess.ToString();
            }
            else if(allFailed)
            {
                TempData["FailedInput"] = sbFailed.ToString();
            }
            else
            {
                TempData["SuccessInput"] = sbSuccess.ToString();
                TempData["FailedInput"] = sbFailed.ToString();
            }
            return Redirect("Input");
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> History(string search, string sortTypes)
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<Transaction> transactions;
            if (String.IsNullOrEmpty(sortTypes))
            {
                sortTypes = "Date";
            }
            if (String.IsNullOrEmpty(search))
            {
                transactions = await _transactionRepository.GetTransactionsFromIdAsync(id, sortTypes);
            }
            else
            {
                transactions = await _transactionRepository.SearchTransactionsFromIdAsync(id, search, sortTypes);
                ViewData["SearchQuery"] = search;
            }
            ViewData["SortQuery"] = sortTypes;
            return View(transactions);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> Export(string search, string sortTypes)
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<Transaction> transactions;
            if (String.IsNullOrEmpty(sortTypes))
            {
                sortTypes = "Date";
            }
            if (String.IsNullOrEmpty(search))
            {
                transactions = await _transactionRepository.GetTransactionsFromIdAsync(id, sortTypes);
            }
            else
            {
                transactions = await _transactionRepository.SearchTransactionsFromIdAsync(id, search, sortTypes);
                ViewData["SearchQuery"] = search;
            }
            ViewData["SortQuery"] = sortTypes;
            DataTable table = new DataTable();
            table.TableName = "Transaction Table 1";
            table.Columns.Add("Admin");
            table.Columns.Add("Intern Full Name");
            table.Columns.Add("Intern Email");
            table.Columns.Add("Total Bootcoin");
            table.Columns.Add("Input");
            table.Columns.Add("Date");
            table.Columns.Add("Position");
            table.Columns.Add("Group");
            foreach(var transaction in transactions)
            {
                DataRow td = table.NewRow();
                td["Admin"] = transaction.User.FullName;
                td["Intern Full Name"] = transaction.Receiver.FullName;
                td["Intern Email"] = transaction.Receiver.Email;
                td["Total Bootcoin"] = transaction.Receiver.BootCoin;
                td["Input"] = transaction.amount;
                td["Date"] = transaction.Date.ToString("dd/MM/yyyy");
                td["Position"] = transaction.Receiver.Position.PositionName;
                td["Group"] = transaction.Receiver.Group.GroupName;
                table.Rows.Add(td);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                workbook.Worksheets.Add(table);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return File(memoryStream.ToArray(), "Application/vnd.ms-excel", "Transaction_History_by_"+transactions.First().User.FullName+".xlsx");
                }
            }
        }
    }
}
