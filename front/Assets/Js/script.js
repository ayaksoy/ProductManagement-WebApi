getAllCategory();

function getAllCategory() {
	$.ajax({
		method: 'GET',
		url: 'http://localhost:5179/api/Category',
		crossDomain: true,
		dataType: 'json',
		success: function (data) {
			categoryDisplay(data);
		}
	});
}

function categoryDisplay(category){
	var categoryList = $('#categories');
	categoryList.empty();
	$.each(category, function(index, cat) {
		categoryList.append(`		
			<tr>
			<td>${cat.id}</td>
			<td>${cat.name}</td>
			<td>${cat.description}</td>
			<td>${cat.isStatus}</td>
			<td>
				<button class="btn btn-danger">Delete</button>
				<button class="btn btn-success">Update</button>
			</td>
		</tr>`);
	});
}

$('#addCategoryForm').submit(function (event) {
var categoryName = $('#Name').val();
var categoryDescription = $('#Description').val();
var categoryStatus = $('#Status');
var categoryData = {
	name: categoryName,
	description: categoryDescription,
	isStatus: categoryStatus.is(':checked')? true : false
};
$.ajax({
	method: 'POST',
	url: 'http://localhost:5179/api/Category',
	crossDomain: true,
	dataType: 'json',
	headers:{
		'Content-Type': 'application/json'
	},
	data: JSON.stringify(categoryData),
	success: function (data) {
		getAllCategory();
		alert('Category Added Successfully');
	}
	})
}
)
function deleteCategory(id) {
$ajax({
	url: 'http://localhost:5179/api/Category/' + id,
	method: 'DELETE',
	success: function (data) {
		getAllCategory();
	}
})						
					}