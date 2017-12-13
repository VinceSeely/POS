function Register() {
   var first = document.getElementById("FirstName").value;
   var last = document.getElementById("LastName").value;
   var username = document.getElementById("Username").value;
   var password = document.getElementById("Password").value;
   var confirmPassword = document.getElementById("PasswordConfirmation").value;
   var phoneNumber = document.getElementById("PhoneNumber").value;
   var streetAddress = document.getElementById("StreetAddress").value;
   var city = document.getElementById("City").value;
   var state = document.getElementById("State").value;
   var zip = document.getElementById("ZipCode").value;
   var country = document.getElementById("Country").value;
   if (first == "" || last == "" || username == "" || password == "" || confirmPassword == "" || phoneNumber == "") {
      alert("Enter all required fields");
   }
   else {
      $.ajax({
         url: "/Home/IsUsernameAvailable",
         data: { 'username': username },
         success: function (data) {
            if (!data) {
               alert("Username is Taken!");
               document.getElementById("Username").value;
            }
            else {
               if (password != confirmPassword) {
                  alert("Passwords do not match!");
                  document.getElementById("Password").value = "";
                  document.getElementById("PasswordConfirmation").value = "";
               }
               else {
                  $.ajax({
                     url: "/Home/RegisterUser",
                     data: {
                        'first': first,
                        'last': last,
                        'username': username,
                        'password': password,
                        'newPhoneNumber': phoneNumber,
                        'address': streetAddress,
                        'state': state,
                        'country': country,
                        'city': city,
                        'zipcode': zip
                     },
                     success: function (data) {
                        if (data) {
                           location.href = "LogIn";
                           alert("Successful Registration");
                        }
                        else
                           alert("Registration Failed");
                     }
                  })
               }
            }
         }

      });
   }
}