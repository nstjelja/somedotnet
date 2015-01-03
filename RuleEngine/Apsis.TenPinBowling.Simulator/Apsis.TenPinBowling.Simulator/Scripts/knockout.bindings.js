ko.bindingHandlers.onEnter = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        
        var allBindings = allBindingsAccessor();
      
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                $('input').blur();
                allBindings.onEnter.call(viewModel);
                return false;
            }
            return true;
        });
    }
};

ko.extenders.makeNumeric = function (target, precision) {
    
    var result = ko.computed({
        read: target, 
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : parseFloat(+newValue),
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
              
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    });

    result(target());

    return result;
};