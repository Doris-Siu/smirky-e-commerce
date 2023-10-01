redirectToCheckout = function (sessionId) {
    var stripe = Stripe("pk_test_51NwWrCEB87jBL3XaMZSAVIIM2eGkRC39O6uXY6ZDP4egNnhuPhntDxFVJnSwwjhO5AU3Z6Tv2GBMCU0OvPRmyDzc004pt8pNKc");
    stripe.redirectToCheckout({ sessionId: sessionId }); }
