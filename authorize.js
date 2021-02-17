function RegisterGo()
{
	$.getJSON('http://localhost/AM/API/user/changepageauthority_test_true', function(data){
		if(data.Success)
			console.log(data.Data);
		else
			console.log(data.Message);
	});
}

function SubmitGo()
{
	var user = document.getElementById("Name").value;
	var password = document.getElementById("Password").value;
	if(user == '' || password == '')
	{
		alert('Please enter user name and password!!');
		return;
	}

	$.ajax({
		url: 'http://localhost/AM/API/user/login',
        type: 'POST',
        data: JSON.stringify({user: user, password: password}), 
        contentType:'application/json',
        error: function(data) 
        {
        	console.log("execution failed!!");
        },
        success: function(data) {
        	if(data.Success)
			console.log(data.Data);
		else
			console.log(data.Message); }
	});
}