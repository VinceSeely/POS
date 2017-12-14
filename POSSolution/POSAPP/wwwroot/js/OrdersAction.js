//function ViewOrders() {
//   var indexOfDir = window.location.href.indexOf("/", 7);
//   var subString = window.location.href.substr(indexOfDir)
//   var queryLocation = "";
//   if (subString.startsWith("/Home"))
//      queryLocation = "Orders";
//   else
//      queryLocation = "Home/Orders";
//   $.ajax({
//      url: queryLocation,
//      success: function (data) {
//         //alert("success");
//         window.location.href = queryLocation;
//      }
//   });
//}

function checkout()
{
   $.ajax({
      url: "/Home/Checkout",
      success: function (data) {
         if (data)
            alert("checked out");
         window.location.reload();
      }
   });
}