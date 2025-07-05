window.onresize = () => {
    const togglerButton = document.getElementsByClassName("offer-application-info-2-toggler")[0];

    if (togglerButton?.classList.contains("collapsed") && window.innerWidth >= 992)
        togglerButton.click();
}

window.initShowOffer = async () => {
    let togglerButton = document.getElementsByClassName("offer-application-info-2-toggler")[0];

    for (let i = 0; i < 50; i++) {
        if (togglerButton) {
            togglerButton = document.getElementsByClassName("offer-application-info-2-toggler")[0];

            togglerButton.addEventListener('onclick', (e) => {
                button = HTMLElement(e.target);

                button.toggleAttribut('active');
            });

            break;
        }
        await new Promise(res => setTimeout(res, 50));
    }   
}