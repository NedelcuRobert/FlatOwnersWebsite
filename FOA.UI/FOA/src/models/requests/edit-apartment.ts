export class EditApartmentRequest {
    numberOfPersons!: string;
    phoneNumber!: string;
}


export class WaterConsumptionRequest {
    apartmentId!: number;
    coldKitchen!: number;
    coldBathroom!: number;
    hotKitchen!: number;
    hotBathroom!: number;
}
