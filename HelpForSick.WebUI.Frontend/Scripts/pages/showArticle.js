(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$finalTitle = undefined;
        this.$imgProf = undefined;
        this.$userPlace = undefined;

        this.initialize = function () {
            this.$finalTitle = $("#divText");
            this.$imgProf = $("#imgProfile");
            this.$userPlace = $("#userPlace");
            
           
        };



        this.loadFormattedText = function () {


            var xhr = $.ajax({
                url: "/Home/GetFormattedText_Show",
                dataType: "json",
                type: "POST",
                data: {

                }
            });

            xhr.done(function (data) {
                var decodedText = unescape(data.formattedText);
                var replacedText = decodedText.split('+').join(' ');

                var htmlText = $.parseHTML(replacedText);
                that.$finalTitle.append(htmlText);
            });
        };

    };

    $(function () {
        var page = new IndexPage();
        page.initialize();
       // page.setImageSrc();
        page.loadFormattedText();
    });


})(jQuery);