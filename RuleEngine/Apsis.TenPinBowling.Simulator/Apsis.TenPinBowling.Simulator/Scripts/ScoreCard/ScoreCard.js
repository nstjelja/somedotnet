function ScoreCard() {
    var self = this;

    this.Frames = ko.observableArray();
    this.Messages = ko.observableArray();
    this.IsError = ko.observable(false);

    this.SubmitScore = function () {
        self.InitAjaxCall();
    };

    this.ResetGame = function () {
        self.PopulateScoreCard();
    };

    this.PopulateScoreCard();

    this.ModelValidationErrors =
            ko.computed(function () {
                return ko.validation.group(self.Frames(), { deep: true })
            });

    this.IsModelValid = ko.computed(function () {
        return (self.ModelValidationErrors()().length == 0);
    });
}



ScoreCard.prototype.PopulateScoreCard = function () {
    this.IsError(false);
    this.Messages([]);
    this.Frames([]);
    this.Frames.push(new Frame(true, true, true));
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame());
    this.Frames.push(new Frame(false));
    this.Frames.push(new Frame(false));
}

ScoreCard.prototype.InitAjaxCall = function () {
    var self = this;

    if (!self.IsModelValid())
        return;

    var score = { Frames: [] };

    self.Frames().forEach(function (frame) {
        score.Frames.push({
            First: frame.First() == undefined ? 0 : frame.First(),
            Second: frame.Second() == undefined ? 0 : frame.Second()
        });
    });

    self.Messages([]);
    self.IsError(false);

    $.ajax("/Home/CalculateScore", {
        data: JSON.stringify(score),
        contentType: "application/json",
        processData: false,
        type: "POST",
        success: function (result) {
           
            self.OnSaveSuccess(result);
        
        },
        error: function (xhr) {
            self.OnSaveError(xhr);
            
        }
    });
}

ScoreCard.prototype.OnSaveError = function (xhr) {
    self.IsError(true);
    self.Messages.push("Error occured on the server");
}

ScoreCard.prototype.OnSaveSuccess = function (result) {
    var self = this;

    self.IsError(result.IsError);

    self.Messages(result.Messages);
   
    if (self.IsError())
        return;

    var breakSearch = false;
    var lastActiveFrameIndex = 0;
    var lastActiveFrame = null;

    self.Frames().forEach(function (frame, index) {
        if (breakSearch)
            return;

        if (frame.IsFilled() == true)
            return;
      
        breakSearch = true;
        lastActiveFrameIndex = index;

        frame.IsFilled(true);
        frame.IsActive(false);
        frame.Score(result.Score);
        
        lastActiveFrame = frame;
    });

    if (lastActiveFrameIndex == 9 && (lastActiveFrame.IsStrike() || lastActiveFrame.IsSpare())){
        self.Frames()[10].IsVisible(true);

        if (lastActiveFrame.IsSpare())
            self.Frames()[10].IsSecondEnabledManual(false);
    }

    if (lastActiveFrameIndex == 10 && self.Frames()[9].IsStrike() && lastActiveFrame.IsStrike()) {
        self.Frames()[11].IsVisible(true);
        self.Frames()[11].IsSecondEnabledManual(false);
    }

    var nextFrame = self.Frames()[lastActiveFrameIndex + 1];

    if (nextFrame == undefined || nextFrame == null)
        return;

    nextFrame.IsActive(true);
    nextFrame.HasFocus(true);
}