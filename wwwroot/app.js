function initializeScrollEvent(dotNetReference) {
    window.addEventListener("scroll", () => {
        if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 1000) {
            dotNetReference.invokeMethodAsync("OnScrollToBottom");
        }
    });
}
