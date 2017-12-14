function ViewItem(sku) {
   var indexOfDir = window.location.href.indexOf("/", 7);
   var subString = window.location.href.substr(indexOfDir)
   var queryLocation = "";
   if (subString.startsWith("/Home"))
      queryLocation = "ItemPage?sku=" + sku;
   else
      queryLocation = "Home/ItemPage?sku=" + sku;
   $.ajax({
      url: queryLocation,
      success: function (data) {
         //alert("success");
         window.location.href = queryLocation;
      }
   });
}

function AddToCart(sku)
{
   $.ajax({
      url: "/Home/AddToCart",
      data: { 'sku': sku },
      success: function (data) {
         if (data)
         {
            location.href = "/Home/Search?searchTerm=";
            alert("Successfully added to cart");
         }
            
      }
   });
}