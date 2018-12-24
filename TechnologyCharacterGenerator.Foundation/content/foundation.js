
window.foundation = {
    collapsiblePanel: {
        init: function (dotNetComponent, componentId, isCollapsed) {
            $(function() {
                var $collapsiblePanel = $('#' + componentId);

                $collapsiblePanel.collapse(isCollapsed ? 'hide' : 'show');

                $collapsiblePanel.on('hide.bs.collapse',
                    function() {
                        dotNetComponent.invokeMethodAsync('UpdateIsCollapsed', true);
                    });

                $collapsiblePanel.on('show.bs.collapse',
                    function() {
                        dotNetComponent.invokeMethodAsync('UpdateIsCollapsed', false);
                    });
            });
        }
    }
};