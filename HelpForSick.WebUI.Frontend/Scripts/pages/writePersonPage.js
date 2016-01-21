(function ($) {

    var WritePersonPage = function () {

        var that = this;

        
        this.$txtDiagnosis = undefined;
        this.$tareaMoneyInfo = undefined;
        this.$tareaMainInfo = undefined;
        this.$saveButton = undefined;
        this.$imageUpload = undefined;

        this.initialize = function () {
            this.$txtDiagnosis = $('#txtDiagnosis');
            this.$tareaMoneyInfo = $('#tareaMoneyInfo');
            this.$tareaMainInfo = $('#tareaMainInfo');
            this.$saveButton = $("#save-button");
            this.$tareaMainInfo.wysihtml5();
            this.$tareaMoneyInfo.wysihtml5();
            this.$imageUpload = $("#imageUpload");

            this.$saveButton.on("click", this.onSaveButton);
        };

        this.onSaveButton = function () {
            var formattedMainInfo = that.$tareaMainInfo.val();
            var formattedMoneyInfo = that.$tareaMoneyInfo.val();
            var formattedDiagnosis = that.$txtDiagnosis.val();
            //var imageFiles = [];
            // imageFiles = that.$imageUpload[0].files;
           // var imageFiles = [];
            var imageFiles = that.$imageUpload[0].files[0];
            // Create a new FormData object.
            var formData = new FormData();
            formData.append("image", imageFiles);

            var xhr = $.ajax({
                url: "/Home/SaveFormattedPersonInfo",
                dataType: "json",
                type: "POST",
                data: {
                    formattedMainInfo: escape(formattedMainInfo),
                    formattedMoneyInfo: escape(formattedMoneyInfo),
                    formattedDiagnosis: escape(formattedDiagnosis),
                    formData
                }
            });

            xhr.done(function (data) {
                console.log("saveButton_Click - done", arguments);
                window.location.href = "/Home/PersonPage";
            });
        };


        this.loadFormattedText = function () {
           // var articleId = that.$saveButton.data('article-id');

            var xhr = $.ajax({
                url: "/Home/GetFormattedPersonInfo",
                dataType: "json",
                type: "POST",
                data: {
                }
            });

            xhr.done(function (data) {
                var decodedMainInfo = unescape(data.formattedMainInfo);
                var decodedDiagnosis = unescape(data.formattedDiagnosis);
                var decodedMoneyInfo = unescape(data.formattedMoneyInfo);
                var mainInfo = decodedMainInfo.split('+').join(' ');
                var diagnosis = decodedDiagnosis.split('+').join(' ');
                var moneyInfo = decodedMoneyInfo.split('+').join(' ');

                //var htmlText = $.parseHTML(replacedText);
                that.$tareaMainInfo.data("wysihtml5").editor.setValue(mainInfo);
                that.$tareaMoneyInfo.data("wysihtml5").editor.setValue(moneyInfo);
                that.$txtDiagnosis.val(diagnosis);
                //that.$finalTitle.append(htmlText);
            });
        };

    };

    $(function () {
        var page = new WritePersonPage();
        page.initialize();
        page.loadFormattedText();
    });


})(jQuery);