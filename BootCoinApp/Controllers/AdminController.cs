using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using BootCoinApp.ViewModels;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BootCoinApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly ITransactionRepository _transactionRepository;
        
        public AdminController(UserManager<AppUser> userManager, IUserRepository userRepository, ITransactionRepository transactionRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> Input(string search)
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<AppUser> users;
            if(String.IsNullOrEmpty(search))
            {
                users = await _userRepository.GetAllInternExceptIdAsync(id);
            }
            else
            {
                users = await _userRepository.SearchInternExceptIdAsync(id, search);
                ViewData["SearchQuery"] = search;
            }
            AppUser CurrentUser = await _userRepository.GetByIdAsync(id);
            var model = new IndexHomeViewModel
            {
                currentUser = CurrentUser,
                users = users,
                usersCount = users.Count(),
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.admin)]
        public IActionResult InputCoinPerUser(int totalCoins, String events, String activeness)
        {
            ViewBag.TotalCoins = totalCoins;
            ViewBag.Events = events;
            ViewBag.Activeness = activeness;
            return View("Result");
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.admin)]
        public IActionResult InputCoinPerGroup(string group, int totalCoins, String events, String activeness)
        {
            ViewBag.Group = group;
            ViewBag.TotalCoins = totalCoins;
            ViewBag.Events = events;
            ViewBag.Activeness = activeness;
            return View("Result");
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.admin)]
        public async Task<IActionResult> History(string search)
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<Transaction> transactions;
            if (String.IsNullOrEmpty(search))
            {
                transactions = await _transactionRepository.GetTransactionsFromIdAsync(id);
            }
            else
            {
                transactions = await _transactionRepository.SearchTransactionsFromIdAsync(id, search);
                ViewData["SearchQuery"] = search;
            }
            return View(transactions);
        }

        public async Task<IActionResult> Export()
        {
            string id = _userManager.GetUserId(User);
            IEnumerable<Transaction> transactions = await _transactionRepository.GetTransactionsFromIdAsync(id);
            DataTable table = new DataTable();
            table.TableName = "Transaction Table 1";
            table.Columns.Add("Admin");
            table.Columns.Add("Intern UserName");
            table.Columns.Add("Total Bootcoin");
            table.Columns.Add("Input");
            table.Columns.Add("Date");
            table.Columns.Add("Position");
            table.Columns.Add("Group");
            foreach(var transaction in transactions)
            {
                DataRow td = table.NewRow();
                td["Admin"] = transaction.User.UserName;
                td["Intern UserName"] = transaction.Receiver.UserName;
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
                    return File(memoryStream.ToArray(), "Application/vnd.ms-excel", "Transaction_History_by_"+transactions.First().User.UserName+".xlsx");
                }
            }
        }
    }
}
