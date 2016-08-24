(function () {

    $(initializePage);

    function initializePage() {
        $('#firstName').focus();
        initializeFormValidation();
    }
    function initializeFormValidation() {
        console.log('Registration Page Ready');
        addCustomValidation();
        console.log($.validator);
        $('#registerForm').validate(
        {
            rules: {
                firstName: {
                    required:true,
                    onlyAlphabets: true
                },
                surName: {
                    required: true,
                    onlyAlphabets: true
                },
                emailAddress: {
                    required: true,
                    email: true
                },
                userName: {
                    required: true,
                    onlyAlphanumeric: true
                },
                password: {
                    required: true,
                    hasUppercaseLetter: true,
                    hasLowercaseLetter: true,
                    hasNumber: true,
                    notSimilarToEmail: true,
                    notSimilarToUsername: true,
                },
                passwordConfirm: {
                    required: true,
                    equalTo: '#password',
                }
            },
            messages: {
                passwordConfirm: { equalTo: "Passwords must match." }
            },
            debug: true,
            submitHandler: submitForm,
            // Bootstrap error highlighting compatibility
            highlight: function (element) {
                $(element).closest('.form-group').addClass('has-error');
            },
            unhighlight: function (element) {
                $(element).closest('.form-group').removeClass('has-error');
            },
            errorElement: 'span',
            errorClass: 'help-block',
            errorPlacement: function (error, element) {
                if (element.parent('.input-group').length) {
                    error.insertAfter(element.parent());
                } else {
                    error.insertAfter(element);
                }
            }
        });
    }

    function addCustomValidation() {
        $.validator.addMethod('notSimilarToUsername', notSimilarToUsername, "Your password cannot contain your username");
        $.validator.addMethod('notSimilarToEmail', notSimilarToEmail, "Your password cannot contain your email");
        $.validator.addMethod('hasUppercaseLetter', hasUppercaseLetter, "Needs at least one upper case letter");
        $.validator.addMethod('hasLowercaseLetter', hasLowercaseLetter, "Needs at least one lower case letter");
        $.validator.addMethod('hasNumber', hasNumber, "Needs at least one number");
        $.validator.addMethod('onlyAlphabets', onlyAlphabets, "Alphabet only");
        $.validator.addMethod('onlyAlphanumeric', onlyAlphanumeric, "Alphabet, numbers, and underscore only");
    }
    function onlyAlphanumeric(value, element) {
        return /^[A-Za-z0-9_]*$/.test(value);
    }

    function onlyAlphabets(value, element) {
        return /^[A-Za-z]*$/.test(value);
    }

    function hasUppercaseLetter(value, element) {
        return /[A-Z]+/.test(value);
    }

    function hasLowercaseLetter(value, element) {
        return /[a-z]+/.test(value);
    }

    function hasNumber(value, element) {
        return /[0-9]+/.test(value);
    }

    function notSimilarToEmail(value, element) {
        var similarToEmail = value.toLowerCase().indexOf($('#emailAddress').val().toLowerCase()) != -1;
        return !similarToEmail;
    }

    function notSimilarToUsername(value, element) {
        var similarToUserName = value.toLowerCase().indexOf($('#userName').val().toLowerCase()) != -1;
        return !similarToUserName;
    }

    function submitForm(form) {
        console.log('submitting form...');
        form.submit();
    }
})();

