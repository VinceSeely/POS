function SetCurrentUser()
{
   var username = document.getElementById("Username").value;
   var password = document.getElementById("Password").value;
   $.ajax({
      url: "/Home/SetUser",
      async: false,
      data: { 'username': username, 'password': password }
   });
}