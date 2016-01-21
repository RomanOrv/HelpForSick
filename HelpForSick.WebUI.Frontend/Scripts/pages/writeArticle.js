(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$htmlEditor = undefined;
        this.$saveButton = undefined;

        this.initialize = function () {

            this.$htmlEditor = $('#htmlEditor');
            this.$saveButton = $("#save-button");
            this.$htmlEditor.wysihtml5();

            this.$saveButton.on("click", this.onSaveButton);
        };

        this.onSaveButton = function () {
            var formattedText = that.$htmlEditor.val();

            var xhr = $.ajax({
                url: "/Home/SaveFormattedText",
                dataType: "json",
                type: "POST",
                data: {
                    formattedText: encodeURIComponent(formattedText)
                }
            });

            xhr.done(function (data) {
                console.log("saveButton_Click - done", arguments);
                window.location.href = "/Home/Index";
            });
        };


        this.loadFormattedText = function () {
            var articleId = that.$saveButton.data('article-id');

            var xhr = $.ajax({
                url: "/Home/GetFormattedText",
                dataType: "json",
                type: "POST",
                data: {
                }
            });

            xhr.done(function (data) {
                var decodedText = decodeURIComponent(data.formattedText);
                var replacedText = decodedText.split('+').join(' ');

                //var htmlText = $.parseHTML(replacedText);
                that.$htmlEditor.data("wysihtml5").editor.setValue(replacedText);
                //that.$finalTitle.append(htmlText);
            });
        };

    };

    $(function () {
        var page = new IndexPage();
        page.initialize();
        page.loadFormattedText();
    });


})(jQuery);