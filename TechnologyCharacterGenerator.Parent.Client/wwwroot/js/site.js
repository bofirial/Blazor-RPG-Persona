window.statusReportSender = {
  init: function(dotnetStatusReportReceiver) {
    this.statusReportReceiver = dotnetStatusReportReceiver;
  },

  statusReportReceiver: null,

  send: function(statusReport) {
    if (null === statusReportReceiver) {
      console.error('statusReportReceiver has not been initialized');
      return;
    }

    console.log('Sending Status Report: ' + JSON.stringify(statusReport));

    statusReportReceiver
      .invokeMethodAsync('ReceiveStatusReport', statusReport)
      .then(r =>
        console.log('Completed Sending Status Report: ' + JSON.stringify(r))
      );
  }
};

window.childApplicationStarter = {
  startChildApplication: function(childApplicationName, childApplicationUrl) {
    console.log(
      'Starting Child Application: ' +
        childApplicationName +
        ' (' +
        childApplicationUrl +
        ')'
    );

    let frame = document.querySelector(
      '.childApplication.' + childApplicationName
    );

    frame.src = childApplicationUrl;
  }
};
