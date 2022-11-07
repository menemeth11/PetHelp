function triggerButton(id) {
    console.log('triggered click elementRef');
    var elem = document.getElementById(id);
    elem.click();
    console.log(id);
}

export { triggerButton };