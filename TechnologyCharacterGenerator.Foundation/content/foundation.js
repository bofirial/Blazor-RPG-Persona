
window.foundation = {
    isCollapsed: {},
    collapsiblePanel: {
        init: function (dotNetComponent, componentId, isCollapsed) {

            $(function() {
                var $collapsiblePanel = $('#' + componentId + '-content');

                $collapsiblePanel.collapse(isCollapsed ? 'hide' : 'show');

                window.foundation.isCollapsed[componentId] = isCollapsed;

                $collapsiblePanel.on('hide.bs.collapse',
                    function () {
                        dotNetComponent.invokeMethodAsync('UpdateIsCollapsed', true);
                        window.foundation.isCollapsed[componentId]  = true;
                    });

                $collapsiblePanel.on('show.bs.collapse',
                    function () {
                        dotNetComponent.invokeMethodAsync('UpdateIsCollapsed', false);
                        window.foundation.isCollapsed[componentId]  = false;
                    });
            });
        },
        update: function (componentId, isCollapsed) {

            $(function() {

                if (window.foundation.isCollapsed[componentId] !== isCollapsed) {
                    var $collapsiblePanel = $('#' + componentId + '-content');

                    var setCollapsedStatus = function () {
                        $collapsiblePanel.unbind('shown.bs.collapse.update hidden.bs.collapse.update');

                        $collapsiblePanel.collapse(isCollapsed ? 'hide' : 'show');
                    };

                    if ($collapsiblePanel.data()['bs.collapse']._isTransitioning) {
                        $collapsiblePanel.bind('shown.bs.collapse.update hidden.bs.collapse.update', setCollapsedStatus);
                    } else {
                        setCollapsedStatus();
                    }
                }
            });
        }
    }
};