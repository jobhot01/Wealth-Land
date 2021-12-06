using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventsManager : MonoBehaviour
{
    public static int eventSum;
    public Text EventText;
    public Text RandomEventText;
    public Text RandomValueDisplay;
    public Text FixedValueDisplay;
    public Text SumValueDisplay;
    public Text NameDisplay;
    public Sprite MaleCharacter;
    public Sprite FemaleCharacter;
    public Image CharacterDisplay;
    int eventNumbers;
    int cost;//เงินที่เสีย
    int bonus;//เงินที่ได้รับ
    int fixedCost;
    int fixedBonus;
    int eventCost;
    int eventBonus;
    int fixedEvent;
    int randomEvent;
    int costOrBonus;
    int gameturn;
    string gender;

    void Start()
    {
        GetPlayerPrefsValues();
        GetGender();
        CalculateEventNumbers();
        SpecificEvents();
        CalculateEventValues();
        UI_Update();
    }

    void GetPlayerPrefsValues()
    {
        gameturn = PlayerPrefs.GetInt("gameturn");
        gender = PlayerPrefs.GetString("Gender");
        if (LoadScene.playerName == null)
        {
            LoadScene.playerName = "No name detected";
        }
    }

    void GetGender()
    {
        if (gender == null)
        {
            Debug.LogWarning("No gender found");
        }
        else if (gender == "Male")
        {
            CharacterDisplay.sprite = MaleCharacter;
            Debug.Log("Gender: " + gender);
        }
        else if (gender == "Female")
        {
            CharacterDisplay.sprite = FemaleCharacter;
            Debug.Log("Gender: " + gender);
        }
    }

    void CalculateEventNumbers()
    {
        if (gameturn <= 4)
        {
            costOrBonus = Random.Range(1,5);

            if (costOrBonus < 4)
            {
                eventNumbers = Random.Range(1, 5);
                RandomEvents(eventNumbers);
            }
            else if (costOrBonus == 4)
            {
                eventNumbers = Random.Range(17, 20);
                RandomEvents(eventNumbers);
            }
        }
        else if (gameturn >= 5 && gameturn < 8)
        {
            costOrBonus = Random.Range(1,5);

            if (costOrBonus < 4)
            {
                eventNumbers = Random.Range(4, 11);
                RandomEvents(eventNumbers);
            }
            else if (costOrBonus == 4)
            {
                eventNumbers = Random.Range(17, 22);
                RandomEvents(eventNumbers);
            }
        }
        else if (gameturn >= 8)
        {
            costOrBonus = Random.Range(1,5);
            if (costOrBonus < 4)
            {
                eventNumbers = Random.Range(10, 17);
                RandomEvents(eventNumbers);
            }
            else if (costOrBonus == 4)
            {
                eventNumbers = Random.Range(17, 25);
                RandomEvents(eventNumbers);
            }
        }
    }

    void CalculateEventValues()
    {
        randomEvent = bonus - cost;
        fixedEvent = fixedBonus - fixedCost;
        
        eventBonus = bonus + fixedBonus;
        eventCost = cost + fixedCost;
        
        eventSum = eventBonus - eventCost;
        PlayerPrefs.SetInt("EventSum", eventSum);
    }

    void RandomEvents(int RandomEventNumber)
    {
        switch (RandomEventNumber)
        {
            
            case 1: 
                cost = 500;
                RandomEventText.text = "ดูสัตว์พวกนั้นสิน่ารักจัง โอ๊ย! นกกระจอกเทศตัวนี้มันอะไรเนี่ยจิกหัวฉันซะเลือดออกเลย!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 2:
                cost = 800;
                RandomEventText.text = "ไม่นะ! รองเท้าทำงานสุดที่รักของฉันขาดซะแล้ว แบบนี้ต้องเสียเงินซื้อคู่ใหม่อีกน่ะสิ ไม่นะ!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 3:
                cost = 1250;
                RandomEventText.text = "อาหาร...นั้น เพราะอาหารนั้นแน่เลยที่ทำให้ท้องฉันเป็นแบบนี้ อุ้ย! ไม่ไหวแล้วขอเข้าห้องน้ำก่อนนะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 4:
                cost = 1850;
                RandomEventText.text = "โธ่! พี่วินทำกันได้นะ ระหว่างนั่งมอ'ไซต์ไปทำงานดันขับรถเกี่ยวชุดทำงานขาดซะได้";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 5:
                cost = 2500;
                RandomEventText.text = "หัวหน้าที่ทำงานดันยื่นซองขอบริจาคให้เด็กผู้ด้อยโอกาสมา...ฉันไม่กล้าไม่กล้าปฏิเสธหัวหน้าซะด้วยสิ!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 6:
                cost = 2700;
                RandomEventText.text = "น้องแมวแสนรักของฉันมากระซิบข้างหูบอกว่าอยากได้คอนโดใหม่ก็จัดไปเลยสิจ๊ะ...ชุดใหญ่ไฟกระพริบ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 7:
                cost = 3500;
                RandomEventText.text = "ฉันไม่ชอบการไปโรงพยาบาลเอาซะเลยแต่ทำไงได้! ฉันดันหกล้มพลาดตกบันได";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 8:
                cost = 4800;
                RandomEventText.text = "PM 2.5 อันตรายนัก ฉันเป็นคนรักสุขภาพซะด้วยสิ ซื้อเครื่องฟอกอากาศสักตัวดีกว่า";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 9:
                cost = 5700;
                RandomEventText.text = "หลังจากทำงานมาหนัก ๆ พักผ่อนบ้างก็ดีนะ โกทูบาหลี!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 10:
                cost = 8500;
                RandomEventText.text = "เพื่อนที่รักของฉันได้ยืมเงินแล้วจากนั้นเขาก็หายไปเลยติดต่อไม่ได้ ฉันเป็นห่วงเขาจริง ๆ เลย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 11:
                cost = 9500;
                RandomEventText.text = "ไม่นะ! โน๊ตบุ๊คที่ทำงานประจำพังต้องเอาไปซ่อมด่วน! เสียเงินอีกแล้วสินะเรา";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 12:
                cost = 12500;
                RandomEventText.text = "มีคนบอกว่าให้เอาเงินไปลงแชร์กับเขาสิ ได้ผลตอบแทน 120% แต่พอฉันจ่ายเงินไปเข้าก็บล็อคเฟซฉันหนีหายไปเลย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 13:
                cost = 15000;
                RandomEventText.text = "เอ๋?!ไหนในทวิต 'ร้าบาล' บอกว่าบ้านฉันปลอดภัยจากน้ำท่วมไง ไหนตอนนี้ บุ๋มๆๆๆ ... ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 14:
                cost = 17500;
                RandomEventText.text = "ใครบอกว่าฉันทำอาหารไม่เป็น ฉันแค่ลืมปิดแก๊สจนไฟไหม้ครัวเท่านั้นเอง!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 15:
                cost = 20000;
                RandomEventText.text = "ทำไมฉันมันขี้ลืมขนาดนี้นะ! ลืมล๊อคบ้านหวานโจร ของหายเกือบหมดบ้านเลย ดีนะที่มันยังเหลือรองเท้าให้ 1 คู่";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 16:
                cost = 45000;
                RandomEventText.text = "เขาบอกกันว่าโจรขึ้นบ้าน 10 ทีไม่เท่าไฟไหม้ทีเดียวมันเป็นแบบนี้สินะ ไปแล้วบ้านฉันไม่มีประกันซะด้วย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 17:
                bonus = 250;
                RandomEventText.text = "หัวหน้าที่ทำงานได้เลื่อนขั้นแล้วเลี้ยงหมูกระทะ สบายกระเป๋ากินฟรี 1 มื้อ!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 18:
                bonus = 500;
                RandomEventText.text = "ระหว่างเดินไปทำงานมีแบงค์ 500 ลอยมาแปะหน้าฉันเฉยเลยอะไรกันเนี่ย?!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 19:
                bonus = 1250;
                RandomEventText.text = "โรงพยาบาลหรอ ฉันไม่ชอบที่นี่เลย แต่ฉันก็ดีใจที่มีญาติ ๆ มาเยี่ยมแล้วออกค่ารักษาให้ แล้วบางครั้งก็ได้เงินส่วนเกินมาบ้างนะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 20:
                bonus = 2500;
                RandomEventText.text = "เพื่อนที่ยืมเงินแล้วหาย อยู่ดี ๆ ก็กลับเอาเงินมาคืนซะงั้น โชคดีจริง ๆ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 21:
                bonus = 3750;
                RandomEventText.text = "ปีนี้ฉันได้เงินภาษีคืน...หา! เรื่องจริงใช่ไหมเนี่ย?!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 22:
                bonus = 7500;
                RandomEventText.text = "เฮ้ย! ฉันสมัคร'คนละเสี้ยว'ทันได้เงินจากร้าบาลเยอะเลยว้าว!!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 23:
                bonus = 10000;
                RandomEventText.text = "ฉันชอบทำอาหารและดันไปถูกใจพี่ข้างบ้านที่เป็นเชฟเขาเลยขอซื้อสูตรต่อ สำหรับคนอื่นมันจะอร่อยจริงไหมน้าาา";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 24:
                bonus = 25000;
                RandomEventText.text = "ฉันไม่เคยซื้อหวยนะ แต่คุณแม่ดันซื้อแล้วเอามาให้ฉันน่ะสิ ห๊ะ!? ใบนั้นมันถูกรางวัลใหญ่หรอ ไม่จริงน่า";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
        }
    }

    void SpecificEvents()
    {
        switch (gameturn)
        {
            case 1:
                EventText.text = "วู้ววว! ในที่สุดก็ผ่านรอบแรกไปได้! จะออกจากโลกใบนี้ได้ก็ต้องผ่าน 4 รู้แบบนี้ไปให้ได้ทุกเทิร์นสินะ!";
                break;

            case 2:
                fixedCost = 150;
                EventText.text = "ยังไม่ค่อยเข้าใจเรื่องราวในโลกนี้สักเท่าไหร่แต่ก็เริ่มจับทางได้แล้วบ้าง มีตู้กดน้ำอยู่แถวนี้ด้วยหรอ งั้นขอสักขวดละกัน";
                break;
            
            case 3:
                fixedCost = 2500;
                EventText.text = "เยส! เริ่มเข้ามือแล้ว พอเข้าใจมันก็ไม่ยากซะเท่าไรนี่นา โอ้ย! เจ้าหินบ้าทำฉันสะดุดซะได้ อ๊า! เงินฉันปลิวไปหมดแล้ว";
                break;

            case 4:
                EventText.text = "โห! ฉันต้องจ่ายหนี้มากมายขนาดนี้เลยหรอเนี่ย แต่ถึงมันจะหนักหนาสาหัสเท่าไร เราต้องผ่านพ้นไปให้ได้";
                break;

            case 5:
                fixedCost = 3000;
                EventText.text = "ระหว่างอยู่ในนี้ก็เห็นกล่องวิเศษด้วย มันเขียนบอกว่าถ้าหยอดเงินเข้าไป จะได้กลับมา 10 เท่า ฉันเลยหยอดไปซะ 3,000 แต่ไม่เห็นเกิดอะไรขึ้นเลย";
                break;
            
            case 6:
                fixedCost = 1250;
                EventText.text = "อ่า...โลกแห่งการเงินเป็นแบบนี้เองสินะ 'เงินคือการลงทุน' งั้นฉันลงทุนกับหวยบ้างดีกว่าเผื่อจะถูก 10 ล้าน... เอ๋?! อะไรนะฉันไม่ถูกรางวัลหรอ? ก็ซื้อไปตั้งหลายใบนะ";
                break;
            
            case 7:
                EventText.text = "เทิร์นต่อไปต้องจ่ายหนี้แล้วสินะ...เอ้า! ฮึบเข้าไว้นะตัวฉัน!";
                break;

            case 8:
                EventText.text = "หลังจากจ่ายหนี้ โอม...เทพเจ้าสิ่งศักดิ์สิทธิ์ลูกขอเงินสัก 1,000 ด้วยเทอญ...โอ้ย! อะไรมาแปะหน้านี้มันเงิน 1,000 บาท แต่เป็นแบงค์กาโม่นี่หว่า";
                break;

            case 9:
                EventText.text = "เย้!! เรามาเกินครึ่งทางแล้ว! สู้ต่อไปนะตัวฉัน";
                break;

            case 10:
                fixedBonus = 2500;
                EventText.text = "เอ๋? วันนี้สงสัยดวงดีจริง อยู่ดี ๆ มีนกกระดาษ คาบเงินมาให้เฉยเลย 2,500 บาท ว้าว!";
                break;

            case 11:
                fixedCost = 250;
                EventText.text = "ใกล้แล้ว...เทิร์นสุดท้ายแล้วสินะ ถ้าฉันจ่ายหนี้ก้อนนี้ได้ฉันก็จะหลุดพ้นจากโลกนี้สักที วู้วว! เครียดจังกินหมูกระทะซักหน่อยละกัน";
                break;
            
            case 12:
                EventText.text = "เย้! ในที่สุดก็มาถึงจุดตัดสินซักที! ฉันได้เรียนรู้อะไร ๆ จากที่นี่มากมายเลย ถ้าฉันออกจากที่นี่ได้ฉันสัญญากับตัวเองเลยว่าฉันจะต้องบริหารเงินให้ได้ดีขึ้น!!";
                break;
        }
        Debug.Log($"Cost or Bonus: {bonus - cost}");
    }

    void Update()
    {
        
    }

    void UI_Update()
    {
        RandomValueDisplay.text = randomEvent.ToString("N0");
        FixedValueDisplay.text = fixedEvent.ToString("N0");
        SumValueDisplay.text = eventSum.ToString("N0");
        NameDisplay.text = LoadScene.playerName.ToString();

        //Randomed Values
        if (randomEvent > 0)
        {
            RandomValueDisplay.color = new Color (0, 0.65f, 0, 1f);
        }
        else if (randomEvent < 0)
        {
            RandomValueDisplay.color = Color.red;
        }

        //Fixed Values
        if (fixedEvent > 0)
        {
            FixedValueDisplay.color = new Color (0, 0.65f, 0, 1f);
        }
        else if (fixedEvent < 0)
        {
            FixedValueDisplay.color = Color.red;
        }

        //Summary All Values
        if (eventSum > 0)
        {
            SumValueDisplay.color = new Color (0, 0.65f, 0, 1f);
        }
        else if (eventSum < 0)
        {
            SumValueDisplay.color = Color.red;
        }
    }
}
