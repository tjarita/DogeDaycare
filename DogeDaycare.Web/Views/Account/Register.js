(function () {

    $(document).ready(initializePage);

    function initializePage() {
        console.log('Registration Page Ready');
        $('#RegisterForm').validate(
        {
            debug: true,
            submitHandler: submitForm,
        });
    }

    

    function submitForm(form) {
        form.submit();
    }


})();
