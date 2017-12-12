function ProfileViewModel() {
   // Data
   var self = this;
   self.tabs = ['Credit Cards', 'Shipping Addresses', 'Email Addresses'];
};

function ViewProfile() {
   var indexOfDir = window.location.href.indexOf("/", 7);
   var subString = window.location.href.substr(indexOfDir)
   var queryLocation = "";
   if (subString.startsWith("/Home"))
      queryLocation = "Profile";
   else
      queryLocation = "Home/Profile";
   $.ajax({
      url: queryLocation,
      success: function (data) {
         //alert("success");
         window.location.href = queryLocation;
      }
   });
}

ko.applyBindings(new ProfileViewModel());