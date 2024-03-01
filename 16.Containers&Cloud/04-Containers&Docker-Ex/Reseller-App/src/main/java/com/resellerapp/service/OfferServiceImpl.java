package com.resellerapp.service;

import com.resellerapp.model.dto.AddOfferDTO;
import com.resellerapp.model.entity.Condition;
import com.resellerapp.model.entity.ConditionEnum;
import com.resellerapp.model.entity.Offer;
import com.resellerapp.model.entity.User;
import com.resellerapp.repo.OfferRepo;
import com.resellerapp.repo.UserRepo;
import org.springframework.stereotype.Service;

@Service
public class OfferServiceImpl {

    private final OfferRepo offerRepo;
    private final ConditionService conditionService;
    private final UserServiceImpl userService;
    private final UserRepo userRepo;

    public OfferServiceImpl(OfferRepo offerRepo, ConditionService conditionService, UserServiceImpl userService, UserRepo userRepo) {
        this.offerRepo = offerRepo;
        this.conditionService = conditionService;
        this.userService = userService;
        this.userRepo = userRepo;
    }

    public void addOffer(AddOfferDTO addOfferDTO, Long id) {
        Offer offer = new Offer();
        Condition condition = this.conditionService.findCondition(addOfferDTO.getCondition());
        User userById = userService.findUserById(id).orElse(null);

        offer.setCondition(condition);
        offer.setDescription(addOfferDTO.getDescription());
        offer.setPrice(addOfferDTO.getPrice());

        userById.getOffers().add(offer);
        this.offerRepo.save(offer);
        this.userRepo.save(userById);
    }


    //    public Set<Offer> getOffersFromCurrentUser(Long id) {
//        return offerRepo.findAllByUserId(id);
//    }
//
//    public Set<OffersWithUsernamesDTO> getOffersFromOtherUsers(Long id) {
//        Set<Offer> postsByUserIdNot = offerRepo.findOfferByUserIdNot(id);
//
//        return mapToOfferWithUsernameDTO(postsByUserIdNot);
//    }
//
//    private Set<OffersWithUsernamesDTO> mapToOfferWithUsernameDTO(Set<Offer> postsByUserIdNot) {
//        return postsByUserIdNot.stream()
//                .map(e -> {
//                    OffersWithUsernamesDTO currentDTO = new OffersWithUsernamesDTO();
//                    currentDTO.setDescription(e.getDescription())
//                            .setId(e.getId())
//                            .setPrice(e.getPrice())
////                            .setUserLikes(e.getUserLikes())
//                            .setCondition(e.getCondition().getConditionName());
////                            .setUsername(e.getUser().getUsername());
//                    return currentDTO;
//                })
//                .collect(Collectors.toSet());
//    }

    // TODO: 1/26/2023 buy секция с купените вече предмети "purchase history"
    public void buyOfferWithId(Long offerId, Long userBuyerId) {
        User userBuyer = userService.findUserById(userBuyerId).orElse(null);
        User seller = userRepo.findUserByOffers_Id(offerId).orElse(null);
        Offer offerItem = seller.getOffers().stream().filter(e -> e.getId().equals(offerId)).findFirst().orElse(null);
        boolean remove = seller.getOffers().remove(offerItem);

        boolean add = userBuyer.getBoughtItems().add(offerItem);

        userRepo.save(seller);
        userRepo.save(userBuyer);


//        removeOfferById(offerId);
//        offerRepo.save(offerItem);
    }

    public void addTestOffers() {
        User admin1 = userService.findUserById(Long.parseLong("1")).orElse(null);
        User test1 = userService.findUserById(Long.parseLong("2")).orElse(null);

        Offer adminOffer = new Offer().setPrice(23.2)
                .setCondition(conditionService.findCondition(ConditionEnum.EXCELLENT))
                .setDescription("Sony 42\" TV");
        offerRepo.save(adminOffer);
        admin1.getOffers().add(adminOffer);

        Offer adminOffer2 = new Offer().setPrice(11.2)
                .setCondition(conditionService.findCondition(ConditionEnum.GOOD))
                .setDescription("Microwave XR32 Black");
        offerRepo.save(adminOffer2);
        admin1.getOffers().add(adminOffer2);

        Offer adminOffer3 = new Offer().setPrice(31.2)
                .setCondition(conditionService.findCondition(ConditionEnum.GOOD))
                .setDescription("Laptop 5730");
        offerRepo.save(adminOffer3);
        admin1.getOffers().add(adminOffer3);

        Offer adminOffer4 = new Offer().setPrice(41.2)
                .setCondition(conditionService.findCondition(ConditionEnum.GOOD))
                .setDescription("Overplay Album");
        offerRepo.save(adminOffer4);
        admin1.getOffers().add(adminOffer4);

        Offer adminOffer5 = new Offer().setPrice(51.2)
                .setCondition(conditionService.findCondition(ConditionEnum.GOOD))
                .setDescription("Round Table 120cm");
        offerRepo.save(adminOffer5);
        admin1.getOffers().add(adminOffer5);


        Offer testOffer1 = new Offer().setPrice(19.23)
                .setCondition(conditionService.findCondition(ConditionEnum.EXCELLENT))
                .setDescription("Pepper Roaster");
        offerRepo.save(testOffer1);
        test1.getOffers().add(testOffer1);


        Offer testOffer2 = new Offer().setPrice(92.02)
                .setCondition(conditionService.findCondition(ConditionEnum.ACCEPTABLE))
                .setDescription("PS4 Joystick");
        offerRepo.save(testOffer2);
        test1.getOffers().add(testOffer2);

        Offer adminBought1 = new Offer().setPrice(13.23)
                .setCondition(conditionService.findCondition(ConditionEnum.ACCEPTABLE))
                .setDescription("Microphone Wireless");
        offerRepo.save(adminBought1);
        admin1.getBoughtItems().add(adminBought1);

        Offer adminBought2 = new Offer().setPrice(223.23)
                .setCondition(conditionService.findCondition(ConditionEnum.ACCEPTABLE))
                .setDescription("Vacuum Cleaner Ultra");
        offerRepo.save(adminBought2);
        admin1.getBoughtItems().add(adminBought2);

        userRepo.save(admin1);
        userRepo.save(test1);
    }

    public void removeOfferById(Long offerId, Long userId) {
        User user = userRepo.findById(userId).orElse(null);
        Offer offer1 = user.getOffers().stream().filter(e -> e.getId().equals(offerId))
                .findFirst().orElse(null);
        boolean removed = user.getOffers().remove(offer1);

        userRepo.save(user);
        offerRepo.delete(offer1);
    }

}
