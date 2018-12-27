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

        userViewModelUpdater.userViewModelUpdateReceiver
            .invokeMethodAsync('SubmitUserViewModel', userViewModel);
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