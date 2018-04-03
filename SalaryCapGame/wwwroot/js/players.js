$("#myLink").click(function (e) {

	e.preventDefault();
	$.ajax({

		url: $(this).attr("href"), // comma here instead of semicolon   
		success: function () {
			alert("Player Added");  // or any other indication if you want to show
		}

	});

});