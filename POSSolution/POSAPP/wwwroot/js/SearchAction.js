function Search()
{
   var indexOfDir = window.location.href.indexOf("/", 7);
   var subString = window.location.href.substr(indexOfDir)
   var searchValue = document.getElementById("SearchBox").value;
   var queryLocation = "";
   if (subString.startsWith("/Home"))
      queryLocation = "Search?searchTerm=" + searchValue;
   else
      queryLocation = "Home/Search?searchTerm=" + searchValue;
   $.ajax({
      url: queryLocation,
      success: function (data) {
         //alert("success");
         window.location.href = queryLocation;

      }
   });
}