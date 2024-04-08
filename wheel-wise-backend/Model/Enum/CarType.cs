namespace wheel_wise.Model;

public enum CarType
{
    // Acura
    ILX,
    MDX,
    RDX,
    RLX,
    TLX,
    
    /*// Alfa Romeo
    Giulia,
    Stelvio,
    Giulietta,
    '4C',
    8C,
    
    // Aston Martin
    DB11_AstonMartin,
    Vantage_AstonMartin,
    DBS_AstonMartin,
    Rapide_AstonMartin,
    Valkyrie_AstonMartin,
    
    // Audi
    A3_Audi,
    A4_Audi,
    A6_Audi,
    Q5_Audi,
    Q7_Audi,
    
    // Bentley
    ContinentalGT_Bentley,
    Bentayga_Bentley,
    FlyingSpur_Bentley,
    Mulsanne_Bentley,
    Bentayga_Bentley,
    
    // BMW
    3Series_BMW,
    5Series_BMW,
    7Series_BMW,
    X3_BMW,
    X5_BMW,
    
    // Bugatti
    Chiron_Bugatti,
    Veyron_Bugatti,
    Divo_Bugatti,
    Centodieci_Bugatti,
    LaVoitureNoire_Bugatti,
    
    // Buick
    Encore_Buick,
    Enclave_Buick,
    Regal_Buick,
    LaCrosse_Buick,
    Cascada_Buick,
    
    // Cadillac
    CTS_Cadillac,
    Escalade_Cadillac,
    XT5_Cadillac,
    CT6_Cadillac,
    XT4_Cadillac,
    
    // Chevrolet
    Camaro_Chevrolet,
    Corvette_Chevrolet,
    Malibu_Chevrolet,
    Equinox_Chevrolet,
    Silverado_Chevrolet,
    
    // Chrysler
    300_Chrysler,
    Pacifica_Chrysler,
    Voyager_Chrysler,
    Aspen_Chrysler,
    Crossfire_Chrysler,
    
    // Citroen
    C3_Citroen,
    C4_Citroen,
    C5_Citroen,
    Cactus_Citroen,
    Berlingo_Citroen,
    
    // Dodge
    Challenger_Dodge,
    Charger_Dodge,
    Durango_Dodge,
    Journey_Dodge,
    GrandCaravan_Dodge,
    
    // Ferrari
    488GTB_Ferrari,
    Portofino_Ferrari,
    F8Tributo_Ferrari,
    SF90Stradale_Ferrari,
    812Superfast_Ferrari,
    
    // Fiat
    500_Fiat,
    Panda_Fiat,
    Tipo_Fiat,
    500X_Fiat,
    124Spider_Fiat,
    
    // Ford
    Mustang_Ford,
    F150_Ford,
    Explorer_Ford,
    Focus_Ford,
    Escape_Ford,
    
    // Genesis
    G70_Genesis,
    G80_Genesis,
    G90_Genesis,
    GV80_Genesis,
    GV70_Genesis,
    
    // GMC
    Sierra_GMC,
    Acadia_GMC,
    Terrain_GMC,
    Yukon_GMC,
    Canyon_GMC,
    
    // Honda
    Civic_Honda,
    Accord_Honda,
    CRV_Honda,
    Pilot_Honda,
    Odyssey_Honda,
    
    // Hyundai
    Sonata_Hyundai,
    Elantra_Hyundai,
    Tucson_Hyundai,
    SantaFe_Hyundai,
    Palisade_Hyundai,
    
    // Infiniti
    Q50_Infiniti,
    QX60_Infiniti,
    QX80_Infiniti,
    Q60_Infiniti,
    QX50_Infiniti,
    
    // Jaguar
    FType_Jaguar,
    XE_Jaguar,
    XF_Jaguar,
    XJ_Jaguar,
    FPACE_Jaguar,
    
    // Jeep
    Wrangler_Jeep,
    Cherokee_Jeep,
    GrandCherokee_Jeep,
    Compass_Jeep,
    Renegade_Jeep,
    
    // Kia
    Forte_Kia,
    Optima_Kia,
    Sorento_Kia,
    Sportage_Kia,
    Telluride_Kia,
    
    // Lamborghini
    Huracan_Lamborghini,
    Aventador_Lamborghini,
    Urus_Lamborghini,
    Gallardo_Lamborghini,
    Murcielago_Lamborghini,
    
    // Land Rover
    RangeRover_LandRover,
    Discovery_LandRover,
    Defender_LandRover,
    Evoque_LandRover,
    Velar_LandRover,
    
    // Lexus
    ES_Lexus,
    RX_Lexus,
    IS_Lexus,
    NX_Lexus,
    GX_Lexus,
    
    // Lincoln
    Continental_Lincoln,
    Navigator_Lincoln,
    Aviator_Lincoln,
    MKZ_Lincoln,
    Nautilus_Lincoln,
    
    // Maserati
    Ghibli_Maserati,
    Quattroporte_Maserati,
    Levante_Maserati,
    GranTurismo_Maserati,
    GranCabrio_Maserati,
    
    // Mazda
    Mazda3_Mazda,
    Mazda6_Mazda,
    CX5_Mazda,
    CX9_Mazda,
    MX5_Mazda,
    
    // McLaren
    570S_McLaren,
    720S_McLaren,
    P1_McLaren,
    GT_McLaren,
    650S_McLaren,
    
    // Mercedes-Benz
    CClass_MercedesBenz,
    EClass_MercedesBenz,
    SClass_MercedesBenz,
    GLC_MercedesBenz,
    GLE_MercedesBenz,
    
    // Mini
    Cooper_Mini,
    Countryman_Mini,
    Clubman_Mini,
    Convertible_Mini,
    Paceman_Mini,
    
    // Mitsubishi
    Outlander_Mitsubishi,
    EclipseCross_Mitsubishi,
    Mirage_Mitsubishi,
    ASXMitsubishi,
    Lancer_Mitsubishi,
    
    // Nissan
    Altima_Nissan,
    Rogue_Nissan,
    Sentra_Nissan,
    Murano_Nissan,
    Pathfinder_Nissan,
    
    // Pagani
    Huayra_Pagani,
    Zonda_Pagani,
    HuayraRoadster_Pagani,
    ZondaRoadster_Pagani,
    HuayraBC_Pagani,
    
    // Peugeot
    208_Peugeot,
    308_Peugeot,
    508_Peugeot,
    2008_Peugeot,
    3008_Peugeot,
    
    // Porsche
    911_Porsche,
    Panamera_Porsche,
    Cayenne_Porsche,
    Macan_Porsche,
    Taycan_Porsche,
    
    // Ram
    1500_Ram,
    2500_Ram,
    3500_Ram,
    4500_Ram,
    5500_Ram,
    
    // Renault
    Clio_Renault,
    Megane_Renault,
    Captur_Renault,
    Kadjar_Renault,
    Twingo_Renault,
    
    // Rolls-Royce
    Phantom_RollsRoyce,
    Ghost_RollsRoyce,
    Wraith_RollsRoyce,
    Cullinan_RollsRoyce,
    Dawn_RollsRoyce,
    
    // Subaru
    Impreza_Subaru,
    Forester_Subaru,
    Outback_Subaru,
    Legacy_Subaru,
    Crosstrek_Subaru,
    
    // Suzuki
    Swift_Suzuki,
    Vitara_Suzuki,
    Jimny_Suzuki,
    SX4_Suzuki,
    Baleno_Suzuki,
    
    // Tesla
    ModelS_Tesla,
    Model3_Tesla,
    ModelX_Tesla,
    ModelY_Tesla,
    Roadster_Tesla,
    
    // Toyota
    Corolla_Toyota,
    Camry_Toyota,
    RAV4_Toyota,
    Highlander_Toyota,
    Tacoma_Toyota,
    
    // Volkswagen
    Golf_Volkswagen,
    Jetta_Volkswagen,
    Passat_Volkswagen,
    Tiguan_Volkswagen,
    Atlas_Volkswagen,
    
    // Volvo
    S60_Volvo,
    S90_Volvo,
    XC40_Volvo,
    XC60_Volvo,
    XC90_Volvo*/
}