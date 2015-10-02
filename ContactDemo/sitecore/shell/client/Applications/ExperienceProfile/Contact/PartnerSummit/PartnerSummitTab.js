define(
  ["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
  ],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var cidParam = "cid";

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();
              var contactId = cintelUtil.getQueryParam(cidParam);
              var tableName = "";
              var baseUrl = "/sitecore/api/ao/v1/contacts/" + contactId + "/intel/partnersummit";

              providerHelper.initProvider(this.PartnerSummitDataProvider,
                tableName,
                baseUrl,
                this.ExternalDataTabMessageBar);

              providerHelper.getData(this.PartnerSummitDataProvider,
                $.proxy(function (jsonData) {
                    var dataSetProperty = "Data";
                    if (jsonData.data.dataSet != null && jsonData.data.dataSet.partnersummit.length > 0) {
                        var dataSet = jsonData.data.dataSet.partnersummit[0];
                        this.PartnerSummitDataProvider.set(dataSetProperty, jsonData);
                        this.AttendeeIdValue.set("text", dataSet.AttendeeId);
                        this.AttendingValue.set("text", dataSet.Attending);
                    } else {
                        this.AttendeeIdLabel.set("isVisible", false);
                        this.AttendingLabel.set("isVisible", false);
                        this.ExternalDataTabMessageBar.addMessage("notification", this.NoPartnerSummitData.get("text"));
                    }
                }, this));
          }
      });
      return app;
  });