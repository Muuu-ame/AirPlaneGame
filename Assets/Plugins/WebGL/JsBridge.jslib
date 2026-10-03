mergeInto(LibraryManager.library, {
    SendBackButton: function () {
        window.parent.postMessage(
            { type: 'BackButton' },
            '*'
        );
    },

    SendNextButton: function () {
        window.parent.postMessage(
            { type: 'NextButton' },
            '*'
        );
    }
});