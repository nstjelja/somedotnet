$(document).ready(function () {
    ko.validation.init();

    $(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
    var scoreCard = new ScoreCard();
    
    var dom = $('.scoreCard');
    ko.applyBindingsWithValidation(scoreCard, dom.get(0), {insertMessages:false,decorateInputElement:true, errorElementClass:'error',errorsAsTitle:true,messagesOnModified:true,decorateElementOnModified:true});

   


    $('input[type=number]').keypress(function (key) {
        if (key.charCode == 13)
            return true; 
        if (key.charCode < 48 || key.charCode > 57) return false;
    });
});

