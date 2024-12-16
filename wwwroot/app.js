function initializeScrollEvent(dotNetReference) {
    window.addEventListener("scroll", () => {
        if (window.innerHeight + window.scrollY >= document.body.offsetHeight - 50) {
            dotNetReference.invokeMethodAsync("OnScrollToBottom");
        }
    });
}
