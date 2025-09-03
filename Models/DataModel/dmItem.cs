public class ItemModel
{
    public string ItemNo { get; set; }
    public string ItemName { get; set; }
    public string Base { get; set; }
    public string Origion { get; set; }
    public string Fix { get; set; }
    public string Tested { get; set; }
    public string Function { get; set; }
    public string ImageUrl
    {
        get
        {
            return $"~/images/Official/item/{ItemNo}.jpg";
        }
    }
}

public class ItemObject
{
    public string ItemNo { get; set; }
    public string ItemName { get; set; }
    public string ImageUrl
    {
        get
        {
            return $"~/images/Official/item/{ItemNo}.jpg";
        }
    }
}

public class dmItem
{
    public ItemModel ItemModelData { get; set; }
    public List<ItemObject> ItemDatas { get; set; }
    public List<ItemModel> ItemModelList { get; set; }
    public dmItem()
    {
        ItemModelData = new ItemModel();
        ItemDatas = new List<ItemObject>();
        ItemModelList = new List<ItemModel>();
        SetItemData();
        SetItemModel();
    }
    public void SetItemModelData(string itemNo)
    {
        ItemModelData = ItemModelList.FirstOrDefault(x => x.ItemNo == itemNo);
    }
    private void SetItemData()
    {
        ItemDatas.Add(new ItemObject { ItemNo = "A", ItemName = "紅棗" });
        ItemDatas.Add(new ItemObject { ItemNo = "B", ItemName = "枸杞" });
        ItemDatas.Add(new ItemObject { ItemNo = "C", ItemName = "黃耆" });
        ItemDatas.Add(new ItemObject { ItemNo = "D", ItemName = "當歸" });
        ItemDatas.Add(new ItemObject { ItemNo = "E", ItemName = "黨參" });
        ItemDatas.Add(new ItemObject { ItemNo = "F", ItemName = "熟地" });
        ItemDatas.Add(new ItemObject { ItemNo = "G", ItemName = "枸杞" });
        ItemDatas.Add(new ItemObject { ItemNo = "H", ItemName = "黃耆" });
        ItemDatas.Add(new ItemObject { ItemNo = "I", ItemName = "當歸" });
        ItemDatas.Add(new ItemObject { ItemNo = "J", ItemName = "黨參" });
        ItemDatas.Add(new ItemObject { ItemNo = "K", ItemName = "熟地" });
        ItemDatas.Add(new ItemObject { ItemNo = "L", ItemName = "川芎" });
        ItemDatas.Add(new ItemObject { ItemNo = "M", ItemName = "山藥" });
        ItemDatas.Add(new ItemObject { ItemNo = "N", ItemName = "蓮子" });
        ItemDatas.Add(new ItemObject { ItemNo = "O", ItemName = "芡實" });
    }
    private void SetItemModel()
    {
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "A",
            ItemName = "紅棗",
            Base = "Zizyphus jujuba Miller乾燥成熟果實。棗的品種繁多，大小不一，比較出名的有山東樂陵的「金絲小棗」，江蘇泗洪的泗洪大棗，河北黃驊的「冬棗」，山西的「大棗」及浙江的「義烏大棗」等。",
            Origion = "中國華南至華北各省。台灣於 1980 年代引進栽培。苗栗大湖一帶有專業性的栽植，但因栽種面積不普遍，80%還是靠進口。",
            Fix = "去心, 曬乾",
            Tested = "性溫、味甘。歸脾經，胃經。",
            Function = "紅棗有緩和藥性的功能，所以在許多中醫的方子裡，都可以見到它的蹤影；紅棗能補氣養血， 是很好的營養品。紅棗味甘性溫、脾胃經，有補中益氣，養血安神，緩和藥性的功能。現代藥理研究現，紅棗能使血中含氧量增強、滋養全身細胞，是一種藥效緩和的強壯劑。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "B",
            ItemName = "枸杞",
            Base = "Lycium barbarum Linn.的乾燥果實。常見種類爲枸杞(Lycium chinense Miller)，而主要的藥用種類爲寧夏枸杞(Lycium barbarum L.)。",
            Origion = "寧夏是枸杞原產地，野生記載超過2,000年。人工栽培枸杞也有五百年以上歷史。其他地區如陝、甘、蒙、新等地區也有出產，但不若寧夏興盛。",
            Fix = "",
            Tested = "性味甘、平。入肝、腎經、肺經。",
            Function = "枸杞全身都是寶，它集蔬菜、藥療、養身、觀賞於一體，被受歷代文人、醫家、農家、養身家、道家們喜愛。最早記錄於《神農本草經》，被列為上品，謂可｢堅筋骨、輕身不老｣。也正如古藥書《本草匯言》所載：「枸杞能使氣可充，血可補，陽可生，陰可長，火可降，風濕可去，有十全之妙用焉。」"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "C",
            ItemName = "黃耆",
            Base = "本品係豆科植物黃耆Astragalus membranaceus  Bge.或蒙古黃耆Astragalus mongholicus  Bge.的乾燥根。依用途或乾燥或蜜炙。",
            Origion = "分布中國大陸黑龍江、吉林、遼寧、河北、山東、山西、陜西、甘肅、內蒙古、青海、四川、西藏等。蒙古黃耆主產於黑龍江齊齊哈爾，寧安、內蒙昭、察二盟，寧武黑石灘，山西渾沅、陽高、繁峙、沁州等處。",
            Fix = "生用或蜜炙用，兩者藥性不同。",
            Tested = "甘，微溫。歸脾、肺經。",
            Function = "黃耆是藥膳中最常用的中藥之一。所謂耆者，諸葯之長老，由此可見黃耆是非常重要的一味藥。據《本草綱目》記載，黃耆功效為補氣固表，托毒排膿，利尿，生肌。古藥書《珍珠囊》：「黃耆甘溫純陽，其用有五：補諸虛不足，一也；益元氣,二也；壯脾胃，三也；去肌熱，四也；排膿止痛，活血生血，內托陰疽，為瘡家聖藥，五也。」黃耆含有糖類、葉酸和多種氨基酸等成分，所以能提精神，抗疲勞，提高免疫功能，增強抗病能力。對防止氣虛，感冒和感染對防止氣虛，感冒和感染頗為有效。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "D",
            ItemName = "當歸",
            Base = "本品係伞形科植物當歸Angelica sinensis (Oliv.) Diels的乾燥根。",
            Origion = "在中國分布於甘肅、雲南、四川、青海、陝西、湖南、湖北、貴州等地。主產為甘肅東南部岷縣（秦州），產量多，質量好；其次則為陝西、四川、雲南等地。",
            Fix = "曬乾或燻乾，生用或酒炒用。",
            Tested = "甘、辛，溫。歸肝、心、脾經。",
            Function = "當歸也是最常用的中藥之一《本草綱目》記載：當歸補血和血，調經止痛，潤燥滑腸。當歸除了是四物湯的主角外，若氣血兩虛，也常配黃耆、人參補氣生血。當歸含豐富的揮發油及生物鹼，揮發油為油溶性，可使子宮弛緩，也就是說具有安胎作用。而生物鹼為水溶性物，具收縮子宮作用，用來產後排惡露。因此要增強子宮收縮則應久煎以去其揮發油（煮約五十分鐘）；如要促進子宮弛緩，防止流產，則宜後下（在煎藥最後十分鐘將當歸放入）。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "E",
            ItemName = "黨參",
            Base = "黨參為桔梗科植物黨參（Codonopsis pilosula）、素花黨參（Codonopsis pilosula var. modesta）或川黨參（Codonopsis tangshen）的乾燥根。",
            Origion = "黨參為中國常用的傳統補益藥，古代以山西上黨地區出產的黨參為上品，現今在中國東北、華北、西北各地都有分布。早在漢代就有很多人以黨參取代人參，現以甘肅文縣的紋黨最為人愛用。因其參條粗壯、獅頭蛇尾、皮松肉緊、質地柔軟，斷面呈菊花心紋，被稱為紋黨。",
            Fix = "曬乾",
            Tested = "甘、平，歸脾、肺經。",
            Function = "黨參與人參為不同科的植物，雖然都用於氣虛的症狀；但人參大補元氣，並非每一個人都適合使用，尤其有高血壓的人更要特別留心使用。而黨參性平味甘，能強壯健胃、除煩止渴，對緊張有改善效果。《本草從新》：「黨參主補中益氣，和脾胃，除煩渴。中氣微弱，用以調補，甚為平妥。」《本草正義》也記載：｢與人參不甚相遠。其尤可貴者：則健脾而不燥；滋胃陰而不濕；潤肺而不犯寒涼；養血而不偏滋膩，鼓舞清陽，振動中氣而無剛燥之弊。｣"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "F",
            ItemName = "熟地",
            Base = "地黃 Rehmannia glutinosa Libosch 的新鮮或乾燥塊根。經加工炮制後成為熟地黃。",
            Origion = "主要產地為中國北方，以河南省焦作市一帶最為著名。焦作市在古時為懷慶縣，因此地出產的地黃功效最佳而頗負盛名，稱為「懷慶地黃」。",
            Fix = "鮮用稱鮮地黃、鮮生地。經乾燥程序稱為乾地黃或乾生地。經加工蒸制後的地黃稱為熟地黃或熟地。三者按炮製不同，性味、用途也不同。熟地通常由生地黃加黃酒拌蒸至內外色黑、油潤，或直接蒸至黑潤而成。",
            Tested = "味甘，性溫；歸肝、腎經。",
            Function = "熟地黃有強心、利尿、降血糖和增強免疫功能等作用，也是常用的滋陰補血的中藥材。如四物湯用的就是當歸、川芎、白芍、熟地四味藥。一般使用有分生地、熟地。生地涼血；熟地補血，使用時要特別留意使用的目的。《本草綱目》記載熟地功效為「填骨髓，長肌肉，生精血，補五臟內傷不足，通血脈，利耳目，黑鬚髮。」"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "G",
            ItemName = "茯苓",
            Base = "本品係多孔菌科 (Polyporaceae) 植物茯苓真菌 Poria cocos (Schw.) Wolf 的乾燥菌核。常寄生在松樹根上，形如甘薯，球狀，外皮淡棕色或黑褐色，內部粉色或白色，精製後稱為白茯苓。",
            Origion = "野生或栽培，主產於安徽、河南、雲南、湖北、四川等地。但山東、山西、湖南、貴州、浙江、福建、廣東、廣西等地區亦可見。為茯苓真菌寄生於松科植物赤松或馬尾松等樹根上，深入地下2.0~3.0cm。",
            Fix = "7～9月採集藥材。堆置「發汗」後攤開曬乾，再行「發汗」、晾乾，如此反覆3～4次，最後晾至全乾。生用。切丁或切塊。",
            Tested = "甘、淡，平。歸心、脾、腎經。",
            Function = "茯苓是一種常見的可食用中藥，我們常吃的茯苓糕就是以茯苓粉與麵粉揉合蒸製而成。古人稱茯苓為「四時神藥」，因為它功效非常廣泛，不分四季，將它與各種藥物配伍。茯苓的效果主要是利水滲濕，健脾寧心。以現代的言語來說就是可以利尿、消水腫，提振食慾、促進消化及安靜情緒，幫助入眠。另外茯苓也常被用在美白方面，古醫家認為白茯苓可以很好地去除消除老年斑、黃褐斑，以及婦女產後的黑斑。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "H",
            ItemName = "甘草",
            Base = "為豆科植物甘草Glycyrrhiza uralensis Fisher的乾燥根及根莖。",
            Origion = "甘草分布於中國華北、東北和西北，如內蒙古、山西、甘肅、新疆等地。主要生長於乾旱的荒漠草原裡。",
            Fix = "除去鬚根，曬乾。切厚片，生用或蜜炙用。",
            Tested = "甘，平。歸心、肺、脾、胃經。",
            Function = "李時珍在《本草綱目》中說：「諸藥中甘草為君，治七十二種乳石毒，解一千二百草木毒，調和眾藥有功，故有『國老』之號。」一般情況下，甘草在臨床上並不起主治作用，它的最大作用是輔助其他藥物發揮功效。比如說，它與黨參、白朮等同用，就組成了我們常用的四君子湯、理中丸等，可治脾胃氣虛、倦怠乏力等證；與白芍、白朮、白茯苓同用便成了美白聖藥三白湯。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "I",
            ItemName = "白芍",
            Base = "本品為毛茛科多年生草本植物芍藥 (Paeonia lactiflora Pall.) 的根。",
            Origion = "主產浙江、安徽、西川等地。其他如黑龍江、吉林、遼寧、河北、內蒙等地也多有人工栽培。",
            Fix = "洗凈，除去頭尾及細根，置沸水中煮后除去外皮或去皮后再煮，曬乾。",
            Tested = "苦、酸，微寒。歸肝、脾經。",
            Function = "白芍是芍藥的一種，芍藥始載于《神農本經》中品。陶弘景始分赤、白二種。生白芍以養血斂陰平肝為主。白芍很少獨用，大多做為臣藥輔助君藥的效果。如調經補血的四物湯中配合當歸、川芎、地黃，才成為女性調經的補養聖品。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "J",
            ItemName = "桂皮",
            Base = "為樟科屬植物天竺桂、陰香和川桂的樹皮通稱，肉桂Cinnamomum cassia Presl又稱肉桂、官桂或香桂，為常用中藥，又為食品香料或烹飪調料。",
            Origion = "肉桂原產中國，分布於廣西、廣東、福建、雲南等濕熱地區，其中尤以廣西最多。肉桂大多為人工栽培，且以種子繁殖為主。",
            Fix = "刮去栓皮、陰乾。切片或捲為筒狀。",
            Tested = "味辛、甘，性熱，歸腎、脾、膀胱經。《四川中藥志》入「心、肝、脾、腎」四經。",
            Function = "桂皮香辣氣厚，降而兼升，能走能守。在秦代以前就被廣泛使用於調味，是最早被人类使用的香料之一，適宜食欲不振、腰膝冷痛、心動過慢的人食用。功能上《本草拾遺》：｢治腹內諸冷，血氣脹痛。｣《海藥本草》：補暖腰脚，破產后惡血，治血痢腸風。桂皮性熱，所以夏季應忌食，也不適合便秘、痔瘡患者。桂皮並因有活血的作用，建議孕婦少食。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "K",
            ItemName = "白朮",
            Base = "為菊科植物白朮Atractylodes macrocephala Koidez的乾燥根莖。",
            Origion = "主產於浙江、湖北、湖南、江西、陝西等地，目前連黃土高原皆有引種栽培。",
            Fix = "除去泥沙，烘乾或曬乾，再除去鬚根。切厚片。",
            Tested = "苦、甘，溫。歸脾、胃經。",
            Function = "白朮為補氣健脾的重要藥材，又能燥濕利水，常配於補養藥中，如配人參、乾薑等同用，以溫中健脾，對於腸胃健康及益氣生血很有效果。《本草匯言》：「白朮，乃扶植脾胃，散濕除痹，消食除痞之要藥。脾虛不健，朮能補之；胃虛不納，朮能助之。」白朮也用美白肌膚，常用於祛除面部暗沉及斑點，如外用的七白膏或內服的三白湯。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "L",
            ItemName = "川芎",
            Base = "繖形科多年生草本植物川芎Ligusticum chuanxiong Hort.的乾燥根莖。原名芎藭，因產地十分集中於四川而得名。",
            Origion = "主要分布在四川，以都江堰、重慶、彭縣、新都、大邑、什邡等方圓100公里的川西平原最為有名。現大陸各地多有人工栽培，但四川仍佔川芎整體產量90%已上。",
            Fix = "除去泥沙，曬後烘乾，再去鬚根，切片。",
            Tested = "味辛，溫。入肝、心包經。",
            Function = "川芎主產於四川，最早見於《神農本草經》，並被列為上品。為婦科常用藥，既能活血，又能行氣，可疏風止痛，與當歸同為四物湯的主藥或治頭痛的主藥。《本草綱目》：「川芎血中氣藥也…辛以散之，故氣鬱者宜之」因活血效果更勝於當歸，使用時要特別注意份量。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "M",
            ItemName = "山藥",
            Base = "為薯蕷科植物 Dioscorea opposita Thunb.的乾燥根莖。中國古代的名稱是薯蕷，原產地在河北淮河附近，故又被稱為淮山。",
            Origion = "本品全中國廣為栽培，因生長容易，人工栽培已有數百年歷史，使用歷史可以追溯到宋代，明初河南懷慶已成為山藥的道地產區，入藥以栽培品為主。今分佈極廣，其中以河南新鄉地區溫縣、武陟、沁陽、孟縣、博愛所產者最優，為「四大懷藥」之一；此外，河北、陝西、江蘇、浙江、江西、貴州、四川等地亦有產出。海外遠及日本、高麗及台灣多有產出。",
            Fix = "洗淨，除去外皮和鬚根，乾燥。或先切厚片然後乾燥。",
            Tested = "味甘而性平，入脾、肺、腎三經。",
            Function = "山藥具有健脾、補肺、固腎、益精等多種功效，滋補作用甚佳。認為山藥能「益腎氣、健脾胃、止泄瀉、化痰涎、潤皮毛」則始見於《本草綱目》。山藥價格不貴而有平民補品之稱，因它屬溫、涼補，有補脾氣、益胃等作用，更是滋陰補虛保健食品。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "N",
            ItemName = "蓮子",
            Base = "本品為睡蓮科本植物蓮 (Nelumbo nucifera Gaertn.) 的成熟種子。",
            Origion = "中國自古文人雅士皆愛蓮，幾乎各地都有種植，主產於湖南、福建、江蘇、浙江及南方各地池沼湖溏中。而東南亞各地及台灣也有產出。",
            Fix = "鮮用或曬乾用，或剝去蓮子的外皮和心（青色的胚芽）用，特稱為蓮肉。",
            Tested = "味甘、澀、性平，入脾、腎、心經。而蓮心苦寒，一般都另用。",
            Function = "蓮子是滋補食品，它是荷花的果實，從蓮蓬中取出曬乾。《本草綱目》記載：「蓮子交心腎，厚腸胃，固精氣，強筋骨，補虛損，…止脾瀉泄久痢，赤白濁，女人帶下崩中諸血病。」有助於身體新陳代謝，對於貧血、疲勞患者有很幫助。亦有養心安神、健脾補腎的作用，夏天心浮氣躁的時候吃點蓮子湯很受用。為常用藥食兩用的中藥材之一。"
        });
        ItemModelList.Add(new ItemModel()
        {
            ItemNo = "O",
            ItemName = "芡實",
            Base = "本品為睡蓮科植物芡 (Euryaleferox Salis b.) 的乾燥成熟種仁。",
            Origion = "主產於湖南、江西、安徽、山東等地。芡為觀葉植物，常用於中式庭園水塘造景。芡實是「勾芡」用的「芡粉」的最初來源。",
            Fix = "採收成熟果實，除去果皮，取出種仁，再除去硬殼，曬乾。。",
            Tested = "甘、澀，平。歸脾、腎經。",
            Function = "芡實與蓮子、茯苓、山藥做成四神湯，是民間常見的藥膳。芡實可收斂、滋補澀斂、止瀉。如果是有慢性腹瀉和小便頻仍的人，就可以多吃點芡實。清代醫家陳士擇說：｢芡實止腰膝疼痛，令耳目聰明，久食延齡益壽，視之若平常，用之大有利益，芡實不但止精，而亦能生精也，去脾胃中之濕痰，即生腎中之真水。｣比起蓮子，同為植物果實的芡實要低調許多，其實，在古藥書裡，芡實被稱作是補而不峻、防燥不膩的糧菜佳品。再加上它有著很好的內斂、健脾的作用，在秋冬季進補時，常常為搭配其他補藥的最佳選擇。"
        });
    }
}
