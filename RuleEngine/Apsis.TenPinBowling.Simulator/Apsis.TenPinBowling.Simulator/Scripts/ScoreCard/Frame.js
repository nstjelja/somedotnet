
function Frame(isVisible, isActive, hasFocus) {
    var self = this;

    if (isVisible == undefined || typeof (isVisible) != "boolean") {
        isVisible = true;
    }

    if (isActive == undefined || typeof (isActive) != "boolean") {
        isActive = false;
    }

    if (hasFocus == undefined || typeof (hasFocus) != "boolean") {
        hasFocus = false;
    }

   

    this.First = ko.observable(0).extend({ makeNumeric: 0 });
    this.Second = ko.observable(0).extend({ makeNumeric: 0 });
    this.Score = ko.observable();
    

    this.IsVisible = ko.observable(isVisible);

    this.IsFilled = ko.observable(false);
    this.IsActive = ko.observable(isActive);
    this.HasFocus = ko.observable(hasFocus);

    this.IsSecondEnabledManual = ko.observable(true);

    this.IsSecondEnabled = ko.computed(function () {
        if (!self.IsActive())
            return false;

        if (self.IsFilled())
            return false;

        if (!self.IsSecondEnabledManual())
            return false;

        var first = parseInt(self.First());

        if (first == 10)
            return false;

        return true;
    });


    this.InitValidation();
}

Frame.prototype.InitValidation = function(){
    var self = this;

    //Validation
    var maxValueValidation = {
        validator: function (val, someOtherVal) {
            var first = parseInt(self.First());
            var second = parseInt(self.Second());

            return first + second <= 10;
        },
        message: 'The sum of the first and second rolls must not exceed 10',

    };

    this.First.extend({ required: true, min: 0, max: 10, }).extend({ validation: maxValueValidation });
    this.Second.extend({ required: true, min: 0, max: 10, }).extend({ validation: maxValueValidation });
               
              
}

Frame.prototype.IsStrike = function () {
    return this.First() == 10;

}

Frame.prototype.IsSpare = function () {
    var first = parseInt(this.First());
    var second = parseInt(this.Second());
  
    return first != 10 && ((first + second) == 10);
}