USE AutoSiteProjectDB
GO

----CarOption----
INSERT INTO dbo.CarOption(Name)
SELECT 'Air conditioning'
DECLARE @carOptionAirConditioning  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarOption(Name)
SELECT 'Metallic paint'
DECLARE @carOptionMetallicPaint  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarOption(Name)
SELECT 'Built-in sat nav'
DECLARE @carOptionBuiltinSatNav  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarOption(Name)
SELECT 'Leather seats'
DECLARE @carOptionLeatherSeats  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarOption(Name)
SELECT 'Automatic gearbox'
DECLARE @carOptionAutomaticGearbox  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarOption(Name)
SELECT 'Parking sensors'
DECLARE @carOptionParkingSensors  int = SCOPE_IDENTITY();

----COUNTRIES----
INSERT INTO dbo.Country(Name)
SELECT 'China'
DECLARE @cId int = SCOPE_IDENTITY();

INSERT INTO dbo.Country(Name)
SELECT 'Czech Republic'
DECLARE @crId int = SCOPE_IDENTITY();

INSERT INTO dbo.Country(Name)
SELECT 'France'
DECLARE @fId int = SCOPE_IDENTITY();

INSERT INTO dbo.Country(Name)
SELECT 'Germany'
DECLARE @gId int = SCOPE_IDENTITY();

INSERT INTO dbo.Country(Name)
SELECT 'Italy'
DECLARE @iId int = SCOPE_IDENTITY();

INSERT INTO dbo.Country(Name)
SELECT 'Japan'
DECLARE @jId int = SCOPE_IDENTITY();

----MANUFACTURERS----
--CHINA--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Chery',@cId
DECLARE @cheryId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Emgrand', @cId
DECLARE @emgrandId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Geely', @cId
DECLARE @geelyId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Great Wall', @cId
DECLARE @greatWallId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Lifan', @cId
DECLARE @lifanId int = SCOPE_IDENTITY();

--Czech Republic--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Skoda', @crId
DECLARE @skodaId int = SCOPE_IDENTITY();

--France--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Bugatti', @fId
DECLARE @bugattiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Citroen',@fId
DECLARE @citroenId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Peugeot', @fId
DECLARE @peugeotId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Renault', @fId
DECLARE @renaultId int = SCOPE_IDENTITY();

--Germany--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Audi', @gId
DECLARE @audiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'BMW', @gId
DECLARE @bmwId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Maybach', @gId
DECLARE @maybachId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Mercedes-Benz', @gId 
DECLARE @mercedesBenzId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Opel', @gId 
DECLARE @opelId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Porsche', @gId 
DECLARE @porscheId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Volkswagen', @gId   
DECLARE @volkswagenId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Smart', @gId  
DECLARE @smartId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Wiesmann', @gId  
DECLARE @wiesmannId int = SCOPE_IDENTITY();

--Italy--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Alfa Romeo', @iId
DECLARE @alfaRomeoId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Ferrari', @iId
DECLARE @ferrariId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Fiat', @iId
DECLARE @fiatId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Lamborghini', @iId
DECLARE @lamborghiniId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Lancia', @iId
DECLARE @lanciaId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Maserati', @iId
DECLARE @maseratiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Pagani', @iId
DECLARE @paganiId int = SCOPE_IDENTITY();

--Japan--
INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Acura', @jId
DECLARE @acuraId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Daihatsu', @jId
DECLARE @daihatsuId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Honda', @jId
DECLARE @hondaId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Infiniti', @jId
DECLARE @infinitiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Isuzu', @jId
DECLARE @isuzuId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Lexus', @jId
DECLARE @lexusId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Mazda', @jId
DECLARE @mazdaId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Mitsubishi', @jId
DECLARE @mitsubishiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Nissan', @jId 
DECLARE @nissanId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Subaru', @jId  
DECLARE @subaruId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Suzuki', @jId
DECLARE @suzukiId int = SCOPE_IDENTITY();

INSERT INTO dbo.Manufacturer(Name,CountryId)
SELECT 'Toyota', @jId
DECLARE @toyotaId int = SCOPE_IDENTITY();

----CarBodyTypes----
INSERT INTO dbo.CarBodyType(Name)
SELECT 'Hatchback'
DECLARE @HatchbackId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'Sedan'
DECLARE @SedanId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'MUV/MPV'
DECLARE @MUVMPVId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'SUV'
DECLARE @SUVId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'Cabriolet'
DECLARE @CabrioletId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'Coupe'
DECLARE @CoupeId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarBodyType(Name)
SELECT 'Crossover'
DECLARE @CrossoverId int = SCOPE_IDENTITY();


----CarModels----
--Chery Models--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Arrizo7',@cheryId
DECLARE @cheryArrizo7Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'E5',@cheryId
DECLARE @cheryE5Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'A3',@cheryId
DECLARE @cheryA3Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'E3',@cheryId
DECLARE @cheryE3Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Fulwin2',@cheryId
DECLARE @cheryFulwin2Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'A1',@cheryId
DECLARE @cheryA1Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'New QQ',@cheryId
DECLARE @cheryNQQId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'QQ3',@cheryId
DECLARE @cheryQQ3Id int = SCOPE_IDENTITY();

--Emgrand models--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'EC7',@emgrandId
DECLARE @emgrandEC7Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'EC7-RV',@emgrandId
DECLARE @emgrandEC7RVId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'EC8',@emgrandId
DECLARE @emgrandEC8Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'X7',@emgrandId
DECLARE @emgrandX7Id int = SCOPE_IDENTITY();

--Geely models--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Emgrand GT',@geelyId
DECLARE @geelyEmgrandGTId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GC5',@geelyId
DECLARE @geelyGC5Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GC7',@geelyId
DECLARE @geelyGC7Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'SC7',@geelyId
DECLARE @geelySC7Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GX2',@geelyId
DECLARE @geelyGX2Id int = SCOPE_IDENTITY();

--Greate Wall--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'C50',@greatWallId
DECLARE @greatWallC50Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'H6',@greatWallId
DECLARE @greatWallH6Id int = SCOPE_IDENTITY();

--Lifan--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '530',@lifanId
DECLARE @lifan530Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'L7',@lifanId
DECLARE @lifanL7Id int = SCOPE_IDENTITY();

--Skoda--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Citigo',@skodaId
DECLARE @skodaCitigoId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Fabia',@skodaId
DECLARE @skodaFabiaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Rapid',@skodaId
DECLARE @skodaRapidId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Octavia',@skodaId
DECLARE @skodaOctaviaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Yeti',@skodaId
DECLARE @skodaYetiId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Superb',@skodaId
DECLARE @skodaSuperbId int = SCOPE_IDENTITY();

--Bugatti--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Veyron',@bugattiId
DECLARE @bugattiVeyronId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Chiron',@bugattiId
DECLARE @bugattiChironId int = SCOPE_IDENTITY();

--Citroen--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'C3',@citroenId
DECLARE @citroenC3Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'C4',@citroenId
DECLARE @citroenC4Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'C5',@citroenId
DECLARE @citroenC5Id int = SCOPE_IDENTITY();

--Peugeot--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '308',@peugeotId
DECLARE @peugeot308Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '3008',@peugeotId
DECLARE @peugeot3008Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '307',@peugeotId
DECLARE @peugeot307Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '206',@peugeotId
DECLARE @peugeot206Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '406',@peugeotId
DECLARE @peugeot406Id int = SCOPE_IDENTITY();

--Renault--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Megane',@renaultId
DECLARE @renaultMeganeId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Clio',@renaultId
DECLARE @renaultClioId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Fluence',@renaultId
DECLARE @renaultFluenceId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Espace',@renaultId
DECLARE @renaultEspaceId int = SCOPE_IDENTITY();

--Audi--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'A4',@audiId
DECLARE @audiA4Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'A6',@audiId
DECLARE @audiA6Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'A8',@audiId
DECLARE @audiA8Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Q3',@audiId
DECLARE @audiQ3Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'TT',@audiId
DECLARE @audiTTId int = SCOPE_IDENTITY();
--Bmw--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '320',@bmwId
DECLARE @bmw320Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'x6',@bmwId
DECLARE @bmwX6Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '535',@bmwId
DECLARE @bmw535Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'i8',@bmwId
DECLARE @bmwI8Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'M3',@bmwId
DECLARE @bmwM3Id int = SCOPE_IDENTITY();

--Maybach--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Landaulet',@maybachId
DECLARE @maybachLandauletId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Type 57',@maybachId
DECLARE @maybachType57Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Type 62',@maybachId
DECLARE @maybachType62Id int = SCOPE_IDENTITY();

--Mers--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'W203',@mercedesBenzId
DECLARE @mercedesBenzW203Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'W215',@mercedesBenzId
DECLARE @mercedesBenzW215Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'X164',@mercedesBenzId
DECLARE @mercedesBenzX164Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'R170',@mercedesBenzId
DECLARE @mercedesBenzR170Id int = SCOPE_IDENTITY();
--Opel--

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Astra',@opelId
DECLARE @opelAstraId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Insignia',@opelId
DECLARE @opelInsigniaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Zafira',@opelId
DECLARE @opelZafiraId int = SCOPE_IDENTITY();
--Porsche--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '911',@porscheId
DECLARE @porsche911Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Carrera',@porscheId
DECLARE @porscheCarreraId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Panamera',@porscheId
DECLARE @porschePanameraId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Cayenne',@porscheId
DECLARE @porscheCayenneaId int = SCOPE_IDENTITY();
--Vw--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Golf',@volkswagenId
DECLARE @volkswagenGolfId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Polo',@volkswagenId
DECLARE @volkswagenPoloId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Passat',@volkswagenId
DECLARE @volkswagenPassatId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Touareg',@volkswagenId
DECLARE @volkswagenTouaregId int = SCOPE_IDENTITY();

--Smart--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Roadster',@smartId
DECLARE @smartRoadsterId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Fortwo',@smartId
DECLARE @smartFortwoId int = SCOPE_IDENTITY();

--Wiesman--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'MF',@wiesmannId
DECLARE @wiesmannMFId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'MF3',@wiesmannId
DECLARE @wiesmannMF3Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GT',@wiesmannId
DECLARE @wiesmannGTId int = SCOPE_IDENTITY();

--Alfa Romeo--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '156',@alfaRomeoId
DECLARE @alfaRomeo156Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '4C',@alfaRomeoId
DECLARE @alfaRomeo4CId int = SCOPE_IDENTITY();

--ferrari--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'F430',@ferrariId
DECLARE @ferrariF430Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '360',@ferrariId
DECLARE @ferrari360Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '458',@ferrariId
DECLARE @ferrari458Id int = SCOPE_IDENTITY();

--Fiat--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Panda',@fiatId
DECLARE @fiatPandaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Ducato',@fiatId
DECLARE @fiatDucatoId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Punto',@fiatId
DECLARE @fiatPuntoId int = SCOPE_IDENTITY();

--Lambo--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Gallardo',@lamborghiniId
DECLARE @lamborghiniGallardoId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Aventador',@lamborghiniId
DECLARE @lamborghiniAventadorId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Veneno',@lamborghiniId
DECLARE @lamborghiniVenenoId int = SCOPE_IDENTITY();

--Lancia--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Dedra',@lanciaId
DECLARE @lanciaDedraId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Lybra',@lanciaId
DECLARE @lanciaLybraId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Voyager',@lanciaId
DECLARE @lanciaVoyagerId int = SCOPE_IDENTITY();

--Maserati--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Spyder',@maseratiId
DECLARE @maseratiSpyderId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Quattroporte',@maseratiId
DECLARE @maseratiQuattroporteId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GranTurismo',@maseratiId
DECLARE @maseratiGranTurismoId int = SCOPE_IDENTITY();

--Pagani--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Zonda',@paganiId
DECLARE @paganiZondaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Zonda F',@paganiId
DECLARE @paganiZondaFId int = SCOPE_IDENTITY();

--Acura--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'RSX',@acuraId
DECLARE @acuraRSXId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'MDX',@acuraId
DECLARE @acuraMDXId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'NSX',@acuraId
DECLARE @acuraNSXId int = SCOPE_IDENTITY();

--Daihatsu--

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Sirion',@daihatsuId
DECLARE @daihatsuSirionId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Valera',@daihatsuId
DECLARE @daihatsuValeraId int = SCOPE_IDENTITY();

--Honda--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Civic',@hondaId
DECLARE @hondaCivicId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Accord',@hondaId
DECLARE @hondaAccordId int = SCOPE_IDENTITY();

--Infiniti--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'FX',@infinitiId
DECLARE @infinitiFXId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'G',@infinitiId
DECLARE @infinitiGSedanId int = SCOPE_IDENTITY();

--Isuzu--

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'D Max',@isuzuId
DECLARE @isuzuDMaxId int = SCOPE_IDENTITY();

--Lexus--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'IS 350',@lexusId
DECLARE @lexusIS350Id int = SCOPE_IDENTITY();

--Mazda--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '323',@mazdaId
DECLARE @mazda323Id int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '626',@mazdaId
DECLARE @mazda626Id int = SCOPE_IDENTITY();

--Mitsubishi--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Lancer',@mitsubishiId
DECLARE @mitsubishiLancerId int = SCOPE_IDENTITY();

--Nissan--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT '350Z',@nissanId
DECLARE @nissan350ZId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'GT-R',@nissanId
DECLARE @nissanGTRId int = SCOPE_IDENTITY();

--Subaru--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Impreza',@subaruId
DECLARE @subaruImprezaId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Forester',@subaruId
DECLARE @subaruForesterId int = SCOPE_IDENTITY();

--Toyota--
INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Camry',@toyotaId
DECLARE @toyotaCamryId int = SCOPE_IDENTITY();

INSERT INTO dbo.CarModel(Name,ManufacturerId)
SELECT 'Corolla',@toyotaId
DECLARE @toyotaCorollaId int = SCOPE_IDENTITY();

----ModelBodyTypes----

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @cheryArrizo7Id, @HatchbackId
union
SELECT @cheryArrizo7Id, @CrossoverId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @mercedesBenzW215Id, @SedanId
union
SELECT @mercedesBenzW215Id, @CoupeId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @nissan350ZId, @CoupeId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @audiTTId, @CoupeId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @volkswagenGolfId, @HatchbackId
union
SELECT @volkswagenGolfId, @MUVMPVId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @volkswagenPassatId, @MUVMPVId
union
SELECT @volkswagenPassatId, @SedanId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @ferrariF430Id, @CabrioletId
union
SELECT @ferrariF430Id, @CoupeId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @nissanGTRId, @CoupeId

INSERT INTO dbo.ModelBodyTypes(ModelId,BodyTypeId)
SELECT @subaruForesterId, @SUVId

----CarItem----
INSERT INTO dbo.CarItem(ModelId,BodyTypeId,Description)
SELECT @nissan350ZId,@CoupeId,'Testing program with Nissan =)'
DECLARE @carItemNissan350z  int = SCOPE_IDENTITY();

INSERT INTO dbo.CarItem(ModelId,BodyTypeId,Description)
SELECT @ferrariF430Id,@CoupeId,'Testing program with Ferrari o_O'
DECLARE @carItemFerrariF430  int = SCOPE_IDENTITY();

----CarOptions----
INSERT INTO dbo.CarItemOptions(CarItemId,OptionId)
SELECT @carItemNissan350z,@carOptionLeatherSeats
UNION 
SELECT @carItemNissan350z,@carOptionMetallicPaint
UNION
SELECT @carItemNissan350z,@carOptionAirConditioning

INSERT INTO dbo.CarItemOptions(CarItemId,OptionId)
SELECT @carItemFerrariF430,@carOptionLeatherSeats
UNION 
SELECT @carItemFerrariF430,@carOptionMetallicPaint
UNION
SELECT @carItemFerrariF430,@carOptionAirConditioning
UNION
SELECT @carItemFerrariF430,@carOptionParkingSensors
UNION
SELECT @carItemFerrariF430,@carOptionBuiltinSatNav