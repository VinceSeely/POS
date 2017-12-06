function ViewCart() {
   var indexOfDir = window.location.href.indexOf("/", 7);
   var subString = window.location.href.substr(indexOfDir)
   var queryLocation = "";
   if (subString.startsWith("/Home"))
      queryLocation = "Cart";
   else
      queryLocation = "Home/Cart";
   $.ajax({
      url: queryLocation,
      success: function (data) {
         //alert("success");
         window.location.href = queryLocation;
      }
   });
}