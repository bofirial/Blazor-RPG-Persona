window.setApplicationName = function (applicationName) {
    window.applicationName = applicationName;
};

window.userViewModelUpdater = {
    init: function (dotNetUserViewModelUpdateReceiver) {
        userViewModelUpdater.userViewModelUpdateReceiver = dotNetUserViewModelUpdateReceiver;
    },

    userViewModelUpdateReceiver: null,

    update: function (userViewModel) {
        if (null === userViewModelUpdater.userViewModelUpdateReceiver) {
            console.error('userViewModelUpdateReceiver has not been initialized');
            return;
        }

        console.log('Update: ' + JSON.stringify(userViewModel));

        userViewModelUpdater.userViewModelUpdateReceiver
            .invokeMethodAsync('UpdateUserViewModel', userViewModel);
    },
    submit: function (userViewModel) {
        if (null === userViewModelUpdater.userViewModelUpdateReceiver) {
            console.error('userViewModelUpdateReceiver has not been initialized');
            return;
        }

        window.statusReportSender.send(window.statusReportSender.characterGenerationStartedStatusReport);

        userViewModelUpdater.userViewModelUpdateReceiver
            .invokeMethodAsync('SubmitUserViewModel', userViewModel);
    }
};

window.statusReportSender = {
    prepareCharacterGenerationStartedStatusReport: function (characterGenerationStartedStatusReport) {
        statusReportSender.characterGenerationStartedStatusReport = characterGenerationStartedStatusReport;

        document.getElementById("childUserForm-form").addEventListener('submit', function() {
            window.statusReportSender.send(window.statusReportSender.characterGenerationStartedStatusReport);
        }, false);
    },
    characterGenerationStartedStatusReport: null,
    send: function (statusReport) {
        parentApplicationManager.executeParentApplicationAction('statusReportSender.send', [statusReport]);
    }
};

window.parentApplicationManager = {
    executeParentApplicationAction: function (actionPath, parameters) {

        //TODO: Handle Stand Alone Mode

        window.parent
            .postMessage({ actionPath: actionPath, parameters: parameters }, '*');
    }
};

window.addEventListener('message', function (event) {
    //TODO: Check if message is from Parent Site

    if (event.origin == window.location.origin) {
        return;
    }

    console.log('Message Event: ' + JSON.stringify(event.data));

    var eventData = event.data,
        actionPathParts = eventData.actionPath.split('.'),
        obj = window;

    for (var i in actionPathParts) {
        var property = actionPathParts[i];

        obj = obj[property];
    }

    obj.apply(null, eventData.parameters);
});