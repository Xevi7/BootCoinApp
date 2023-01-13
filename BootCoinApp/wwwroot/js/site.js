// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    // still a bit bugged where the animation plays while not changing the arrow icon
    var isCollapsing = false
    $('.support-card').on('click', function () {
        if (isCollapsing) { return }
        isCollapsing = true

        var supportCard = $(this)
        if (supportCard.find('.material-icons').text() == 'expand_more') {
            supportCard.find('.material-icons').text('expand_less')
            supportCard.find('.support-text').animate({
                fontSize: "24px"
            }, 350)
        }
        else {
            supportCard.find('.material-icons').text('expand_more')
            supportCard.find('.support-text').animate({
                fontSize: "18px"
            }, 350)
        }

        setTimeout(function () {
            isCollapsing = false
        }, 350)
    })

    // underline navbar items
    let currRelativeUrl = location.pathname
    if (currRelativeUrl == '/') {
        $("[id=index]")
            .css('border-bottom', '1px solid #414141')
            .css('padding-bottom', '0')
    }
    else {
        $("[id=index]")
            .css('border-bottom', '1px solid #FFFFFF')
            .css('padding-bottom', '0')
    }
    if (currRelativeUrl == '/Admin/Input') {
        $("[id=input]")
            .css('border-bottom', '1px solid #414141')
            .css('padding-bottom', '0')
    }
    else {
        $("[id=input]")
            .css('border-bottom', '1px solid #FFFFFF')
            .css('padding-bottom', '0')
    }
    if (currRelativeUrl == '/Admin/History') {
        $("[id=history]")
            .css('border-bottom', '1px solid #414141')
            .css('padding-bottom', '0')
    }
    else {
        $("[id=support]")
            .css('border-bottom', '1px solid #FFFFFF')
            .css('padding-bottom', '0')
    }
    if (currRelativeUrl == '/User/Support') {
        $("[id=support]")
            .css('border-bottom', '1px solid #414141')
            .css('padding-bottom', '0')
    }
    else {
        $("[id=support]")
            .css('border-bottom', '1px solid #FFFFFF')
            .css('padding-bottom', '0')
    }
})