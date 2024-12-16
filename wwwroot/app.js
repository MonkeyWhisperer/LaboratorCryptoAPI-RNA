function initializeScrollEvent(dotNetReference) {
    const container = document.getElementById("cryptoTableContainer");
    container.addEventListener("scroll", () => {
        if (container.scrollHeight - container.scrollTop <= container.clientHeight + 50) {
            dotNetReference.invokeMethodAsync("OnScrollToBottom");
        }
    });
}
