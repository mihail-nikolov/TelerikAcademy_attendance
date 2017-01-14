/* globals $ */
$.fn.gallery = function (columns) {
	var columns = columns || 4;
	var $this = this;
	var $gallery = $this.find('.gallery-list');
	var $selected = $this.find('.selected');
	var $imageContainers = $this.find('.image-container');
	var $prevImage = $this.find('#previous-image');
	var $currentImage = $this.find('#current-image');
	var $nextImage = $this.find('#next-image');

	var count = 0;

	$imageContainers.each(function (index, imageContainer) {
		count += 1;
		if (count === columns) {
			var $imageContainer = $(imageContainer);
			$imageContainer.after($('<div />')
				.addClass('clearfix'));
			count = 0;
		}
	});

	$gallery.on('click', '.image-container',
		function () {
			var $this = $(this);
			$currentImage.attr('src', $this.find('img').attr('src'));
			var currentIndex = ($this.find('img').attr('data-info')) - 1;
			var prevIndex = (currentIndex - 1);
			var nextIndex = (currentIndex + 1) % $imageContainers.length;

			var $prev = $imageContainers.eq(prevIndex)
			$prevImage.attr('src', $prev.find('img')
				.attr('src'))
				.attr('data-info', prevIndex + 1);

			var $next = $imageContainers.eq(nextIndex);
			$nextImage.attr('src', $next.find('img').attr('src'))
				.attr('data-info', nextIndex + 1);
			$selected.show();
			$gallery.addClass('blurred').addClass('disabled-background');
		});

	$('#current-image').on('click', function () {
		$selected.hide();
		$gallery.removeClass('blurred').removeClass('disabled-background');
	});

	$this.addClass('gallery');
	$selected.hide();

	$prevImage.on('click', function () {
		var $this = $(this);
		var currentIndex = $this.attr('data-info') - 1;
		var prevIndex = currentIndex - 1;
		var nextIndex = (currentIndex + 1) % $imageContainers.length;

		var $current = $imageContainers.eq(currentIndex).find('img');
		var $prev = $imageContainers.eq(prevIndex).find('img');
		var $next = $imageContainers.eq(nextIndex).find('img');

		$currentImage.attr('src', $current.attr('src'))
			.attr('data-info', currentIndex + 1);

		$prevImage.attr('src', $prev.attr('src'))
			.attr('data-info', prevIndex + 1);

		$nextImage.attr('src', $next.attr('src'))
			.attr('data-info', nextIndex + 1);
	});

	$nextImage.on('click', function () {
		var $this = $(this);
		var currentIndex = $this.attr('data-info') - 1;
		var prevIndex = currentIndex - 1;
		var nextIndex = (currentIndex + 1) % $imageContainers.length;

		var $current = $imageContainers.eq(currentIndex).find('img');
		var $prev = $imageContainers.eq(prevIndex).find('img');
		var $next = $imageContainers.eq(nextIndex).find('img');

		$currentImage.attr('src', $current.attr('src'))
			.attr('data-info', currentIndex + 1);

		$prevImage.attr('src', $prev.attr('src'))
			.attr('data-info', prevIndex + 1);

		$nextImage.attr('src', $next.attr('src'))
			.attr('data-info', nextIndex + 1);
	});

};