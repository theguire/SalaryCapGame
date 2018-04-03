
		var ctx1 = document.getElementById("myChart1");
			var myChart1 = new Chart(ctx1, {
			type: 'bar',
				data: {
			labels: ["6/24", "6/25", "6/26", "6/27", "6/28", "6/29", "6/30"],
					datasets: [{
			data: [25, 10, 30, 21, 17, 30, 14],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#007bff',
						borderWidth: 4,
						pointBackgroundColor: '#007bff',
						fillColor: "rgba(220,220,220,0.3)",
						strokeColor: "rgba(220,220,220,1)",
						pointStrokeColor: "#fff",
						pointHighlightFill: "#fff",
						pointHighlightStroke: "rgba(220,220,220,1)",
					},
					{
			data: [8, 6, -2, 2.1, -3, 5, 4],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#009000',
						borderWidth: 3,
						pointBackgroundColor: '#009000'
					}]
				},

				options: {
			scales: {
			yAxes: [{
			ticks: {
			beginAtZero: true
							}
						}]
					},
					legend: {
			display: false,
					}
				}
			});
		
	
		var ctx2 = document.getElementById("myChart2");
			var myChart2 = new Chart(ctx2, {
			type: 'line',
				data: {
			labels: ["6/24", "6/25", "6/26", "6/27", "6/28", "6/29", "6/30"],
					datasets: [{
			data: [5, -10, 3.1, 2.1, -3, 30, 14],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#007bff',
						borderWidth: 4,
						pointBackgroundColor: '#007bff',
						fillColor: "rgba(220,220,220,0.2)",
						strokeColor: "rgba(220,220,220,1)",
						pointStrokeColor: "#fff",
						pointHighlightFill: "#fff",
						pointHighlightStroke: "rgba(220,220,220,1)",

					},

					{
			data: [8, 6, -2, 2.1, -3, 5, 4],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#009000',
						borderWidth: 3,
						pointBackgroundColor: '#009000'
					}]
				},
				options: {
			scales: {
			yAxes: [{
			ticks: {
			beginAtZero: true
							}
						}]
					},
					legend: {
			display: false,
					}

				}
			});
		

	
		var ctx3 = document.getElementById("myChart3");
			var myChart3 = new Chart(ctx3, {
			type: 'line',
				data: {
			labels: ["6/24", "6/25", "6/26", "6/27", "6/28", "6/29", "6/30"],
					datasets: [{
			data: [25, 10, 30, 21, 17, 30, 14],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#007bff',
						borderWidth: 4,
						pointBackgroundColor: '#007bff',
						fillColor: "rgba(220,220,220,0.2)",
						strokeColor: "rgba(220,220,220,1)",
						pointStrokeColor: "#fff",
						pointHighlightFill: "#fff",
						pointHighlightStroke: "rgba(220,220,220,1)",
					}]
				},
				options: {
			scales: {
			yAxes: [{
			ticks: {
			beginAtZero: true
							}
						}]
					},
					legend: {
			display: false,
					}
				}
			});
		
	
		var ctx4 = document.getElementById("myChart4");
			var myChart4 = new Chart(ctx4, {
			type: 'bar',
				data: {
			labels: ["6/24", "6/25", "6/26", "6/27", "6/28", "6/29", "6/30"],
					datasets: [{
			data: [25, 10, 30, 21, 17, 30, 14],
						lineTension: 0,
						backgroundColor: 'transparent',
						borderColor: '#007bff',
						borderWidth: 4,
						pointBackgroundColor: '#007bff',
						fillColor: "rgba(220,220,220,0.2)",
						strokeColor: "rgba(220,220,220,1)",
						pointStrokeColor: "#fff",
						pointHighlightFill: "#fff",
						pointHighlightStroke: "rgba(220,220,220,1)",
					}]
				},
				options: {
			scales: {
			yAxes: [{
			ticks: {
			beginAtZero: true
							}
						}]
					},
					legend: {
			display: false,
					}
				}
			});
		

	
		function openSlideMenu() {
			document.getElementById('side-menu').style.width = '250px';
		document.getElementById('main').style.marginLeft = '250px';
			}

			function closeSlideMenu() {
			document.getElementById('side-menu').style.width = '0px';
		document.getElementById('main').style.marginLeft = '0px';
			}
		


	
		
		$(document).ready(function () {
			$('#pitchersTable').DataTable();
		});
		
	
		$(document).ready(function () {
			$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
				$.fn.DataTable.tables({ visible: true, api: true }).columns.adjust();
			});

		$('table.table').DataTable({
			ajax: '../ajax/data/arrays.txt',
					scrollY: 200,
					scrollCollapse: true,
					paging: false
				});

				// Apply a search to the second table for the demo
				$('#myTable2').DataTable().search('New York').draw();
			});
		