package com.resellerapp.init;

import com.resellerapp.service.ConditionService;
import com.resellerapp.service.OfferServiceImpl;
import com.resellerapp.service.UserServiceImpl;
import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

@Component
public class FirstInit implements CommandLineRunner {

    private final ConditionService conditionService;
    private final UserServiceImpl userService;
    private final OfferServiceImpl offerService;

    public FirstInit(ConditionService conditionService,
                     UserServiceImpl userService,
                     OfferServiceImpl offerService) {
        this.conditionService = conditionService;
        this.userService = userService;
        this.offerService = offerService;
    }

    @Override
    public void run(String... args) {
        this.userService.initAdmin();
        this.userService.initTest();
        this.conditionService.initConditions();
        offerService.addTestOffers();

    }
}
