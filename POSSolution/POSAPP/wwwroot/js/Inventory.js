function Inventory() {
   var indexOfDir = window.location.href.indexOf("/", 7);
   var subString = window.location.href.substr(indexOfDir)
   var searchValue = document.getElementById("SearchBox").value;
   var queryLocation = "";
   if (subString.startsWith("/Home"))
      queryLocation = "InventoryPg";
   else
      queryLocation = "/Home/InventoryPg";
   $.ajax({
      url: queryLocation,
      success: function (data) {
         //alert("success");
         window.location.href = queryLocation;

      }
   });
}

function AddInventory(sku)
{
   $.ajax({
      url: "/Home/UpdateInventoryCount",
      data: { 'sku': sku }
   });
   window.location.reload();
}