(function ($) {

    var IndexPage = function () {

        var that = this;

        this.$mainInfo = undefined;
        this.$diagnosis = undefined;
        this.$userPlace = undefined;

        this.initialize = function () {
            this.$mainInfo = $("#mainInfo");
            this.$diagnosis = $("#diagnosis");
            this.$moneyInfo = $("#moneyInfo");


        };



        this.loadFormattedText = function () {


            var xhr = $.ajax({
                url: "/Home/GetFormattedPersonInfo",
                dataType: "json",
                type: "POST",
                data: {

                }
            });

            xhr.done(function (data) {
                var decodedMainInfo = decodeURIComponent(data.encodeMainInfo);
                var mainInfo = decodedMainInfo.split('+').join(' ');
                var decodedDiagnosis = decodeURIComponent(data.encodeDiagnosis);
                var diagnosis = decodedDiagnosis.split('+').join(' ');
                var decodedMoneyInfo = decodeURIComponent(data.encodeMoneyInfo);
                var moneyInfo = decodedMoneyInfo.split('+').join(' ');

                var htmlMainInfo = $.parseHTML(mainInfo);
                that.$mainInfo.append(htmlMainInfo);
                var htmlDiagnosis = $.parseHTML(diagnosis);
                that.$diagnosis.append(htmlDiagnosis);
                var htmlMoneyInfo = $.parseHTML(moneyInfo);
                that.$moneyInfo.append(htmlMoneyInfo);
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