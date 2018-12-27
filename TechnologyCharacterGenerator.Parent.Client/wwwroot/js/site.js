window.statusReportSender = {
    init: function (dotnetStatusReportReceiver) {
        statusReportSender.statusReportReceiver = dotnetStatusReportReceiver;
    },

    statusReportReceiver: null,

    send: function (statusReport) {
        if (null === statusReportSender.statusReportReceiver) {
            console.error('statusReportReceiver has not been initialized');
            return;
        }

        statusReportSender.statusReportReceiver
            .invokeMethodAsync('ReceiveStatusReport', statusReport);
    }
};

window.childApplicationManager = {
    childApplicationNames: [],
    startChildApplication: function (childApplicationName, childApplicationUrl) {
        console.log('Starting Child Application: ' + childApplicationName + ' (' + childApplicationUrl + ')');

        childApplicationManager.childApplicationNames.push(childApplicationName);
        let frame = document.querySelector('.childApplication.' + childApplicationName);

        frame.src = childApplicationUrl;
    },
    executeChildApplicationAction: function (actionPath, parameters) {
        for (var i in childApplicationManager.childApplicationNames) {
            var childApplicationName = childApplicationManager.childApplicationNames[i];

            var childApplicationFrame = document.querySelector('.childApplication.' + childApplicationName);

            childApplicationFrame.contentWindow
                .postMessage({ actionPath: actionPath, parameters: parameters }, '*');
        }
    }
};

window.childApplicationUserViewModelUpdater = {

    update: function (userViewModel) {
        console.log('childApplicationUserViewModelUpdater - Update: ' + JSON.stringify(userViewModel));
        window.childApplicationManager.executeChildApplicationAction('userViewModelUpdater.update', [userViewModel]);
    },
    submit: function (userViewModel) {
        window.childApplicationManager.executeChildApplicationAction('userViewModelUpdater.submit', [userViewModel]);
    }
};