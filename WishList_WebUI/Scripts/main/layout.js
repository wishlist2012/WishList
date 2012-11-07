$(document).ready(function () {	
	OrderComments();
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
	$('.post-wrapper .post').wookmark({ offset: 20, autoResize: true });
	$(".post-wrapper").css('visibility', 'visible');
}