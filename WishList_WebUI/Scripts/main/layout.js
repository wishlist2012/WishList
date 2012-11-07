/// <reference path="../jquery-1.7.1.min.js" />

$(document).ready(function () {
	OrderComments();
	FixHeader();
	ScrolUpButton();
})
function OrderComments() {
	var posts = $('.post');
	$.each(posts, function (i) {
		var post = this;
		var comments = $(post).find('div.comment');
		var commentsLenght = comments.length;

		if (commentsLenght > 5) {
			$.each(comments, function (j) {
				if (j > 5) {
					$(this).css('display', 'none');
				}
			});
			$(post).find(".comments").append('<div class="comment"><a id="show-all" href="#">Show all</a></div>');						
		}

	});
	$('.post-wrapper .post').wookmark({ offset: 10, autoResize: true });
	$(".post-wrapper").css('visibility', 'visible');
}

function FixHeader() {
	var topDistance = 40;
	var position;
	var header = $("#bottom-header");
	$(window).scroll(function () {

		position = $(window).scrollTop();

		if (position > topDistance) {
			$(header).css({
				"position": "fixed",				
				"top": 0,
				"width": "100%",
				"z-index": 2000
			});
		}
		else {
			$(header).css({
				"position": "",
				"top": "",
				"width": "",
				"z-index": ""
			});
		}

	});
}

function ScrolUpButton() {

	var scrollHeight = 1.5;
	var height = $(window).height();
	var content = '<div class="scrollup"></div>';
	var scrollup = $(content).appendTo('body');

	$(window).scroll(function () {
		if ($(window).scrollTop() >= height * scrollHeight) {			
			scrollup.fadeIn();
		}
		else {
			scrollup.fadeOut();
		}
	});
	
	scrollup.bind('click', function () {
		$('html, body').animate({ scrollTop: 0 }, 500);
	}).hover(function () {
		$(this).css('cursor', 'pointer');
	});

}