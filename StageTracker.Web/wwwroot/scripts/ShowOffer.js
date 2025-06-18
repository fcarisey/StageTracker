window.onresize = () => {
    let togglerButton = document.getElementsByClassName("offer-application-info-2-toggler")[0];

    if (togglerButton?.classList.contains("collapsed") && window.innerWidth >= 992)
        togglerButton.click();
}