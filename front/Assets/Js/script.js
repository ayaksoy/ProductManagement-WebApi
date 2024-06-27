getAllCategory();

function getAllCategory(){
    $.ajax({
        url:'https://localhost:5179/api/Category',
        method:"GET",
        crossDomain:true,
        dataType:"json",
        success: function (data){
            categoryDisplay(data);
        }
    })
}

function categoryDisplay(categories){
    var categoryList=$("#categories");
    categoryList.empty();

    $.each(categories, function(index,category){
        categoryList.append(`
            <tr>
                <td>${category.id}</td>
                <td>${category.name}</td>
                <td>${category.description}</td>
                <td>${category.isStatus}</td>
                <td>
                    <button class="btn btn-danger" onclick="deleteCategory(${category.id})">Delete</button>
                    <button class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#categoryDetail_${category.id}">Update</button>
                    <div class="modal fade" id="categoryDetail_${category.id}">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h1 class="modal-title fs-5">${category.name}</h1>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria_label="Close"></button>
                                </div>
                                <div class="modal-body">  
                                   
                                        <table class="table">
                                            <tr>
                                                <th>Id</th>
                                                <td>${category.id}</td>
                                                
                                            </tr>
                                            <tr>
                                                <th>Name</th>
                                                <td><input type="text" value="${category.name}" class="form-control" id="updateName_${category.id}"></td>
                                            </tr>
                                            <tr>
                                                <th>Description</th>
                                                <td><input type="text" value="${category.description}" class="form-control" id="updateDescription_${category.id}"></td>
                                            </tr>
                                            <tr>
                                                <th>
                                                    Status 
                                                    <button class="btn btn-${category.isStatus?"success":"danger"} btn-sm">${category.isStatus?"Active":"Passive"}</button>
                                                </th>
                                                <td>
                                                    <select class="form-control" id="updateStatus_${category.id}">
                                                        <option value="true" ${category.isStatus?"selected":""}>Active</option>
                                                        <option value="false"${category.isStatus?"":"selected"}>Passive</option>
                                                    </select>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <button type="button" class="btn btn-success form-control" onclick="updateCategory(${category.id})">Update</button>
                                                </td>
                                            </tr>
                                        </table>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            `)
    })
}

$("#addCategoryForm").submit(function(event){
        var categoryName=$("#Name").val();
    var categoryDescription=$("#Description").val();
    var categoryStatus=$("#Status");
    var categoryData={
        Name:categoryName,
        Description:categoryDescription,
        IsStatus:categoryStatus.is(":checked")?true:false
    };


    $.ajax({
        url:'https://localhost:5179/api/Category',
        method:"POST",
        crossDomain:true,
        dataType:"json",
        headers:{
            'Content-Type':'application/json'
        },
        data:JSON.stringify(categoryData),
        success: function(result){
            getAllCategory();
            alert(result)
        }
        
    })
})

function deleteCategory(id){
    $.ajax({
        url:'https://localhost:5179/api/Category/'+id,
        method:"DELETE",
        success:function(data){
            getAllCategory();
            alert(data);
        }
    })
}


function updateCategory(id){

    var categoryName=$("#updateName_"+id).val();
    var categoryDescription=$("#updateDescription_"+id).val();
    var categoryStatus=$("#updateStatus_"+id).val();
    var categoryData={
        Id:id,
        Name:categoryName,
        Description:categoryDescription,
        IsStatus:categoryStatus=="true"?true:false
    };


    $.ajax({
        url:'https://localhost:5179/api/Category/'+id,
        method:"PUT",
        crossDomain:true,
        dataType:"json",
        headers:{
            'Content-Type':'application/json'
        },
        data:JSON.stringify(categoryData),
        success: function(result){
            alert(result.responseText)
        },
        error: function(result){
            alert(result.responseText)
        }
    })

     window.location.reload();
}