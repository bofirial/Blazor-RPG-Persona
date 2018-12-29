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
    applicationIsRunningInAnIFrame: function() {
        return window.parent && window.parent != window;
    },
    executeParentApplicationAction: function (actionPath, parameters) {

        if (window.parentApplicationManager.applicationIsRunningInAnIFrame()) {
            window.parent
                .postMessage({ actionPath: actionPath, parameters: parameters }, '*');
        }
    }
};

window.addEventListener('message', function (event) {

    if (event.origin === window.location.origin) {
        return;
    }

    var eventData = event.data,
        actionPathParts = eventData.actionPath.split('.'),
        obj = window;

    for (var i in actionPathParts) {
        var property = actionPathParts[i];

        obj = obj[property];
    }

    obj.apply(null, eventData.parameters);
});