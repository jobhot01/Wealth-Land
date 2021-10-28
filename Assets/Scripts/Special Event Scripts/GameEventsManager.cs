using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEventsManager : MonoBehaviour
{
    public static int eventSum;
    public Text EventText;
    public Text RandomEventText;
    public Text ValueDisplay;
    int eventNumbers;
    int cost;//เงินที่เสีย
    int bonus;//เงินที่ได้รับ
    int eventCost;
    int eventIncome;
    int costOrBonus;
    int emergencyExpenditure;
    int gameturn;

    void Start()
    {
        GetPlayerPrefsValues();
        CalculateEventNumbers();
        SpecificEvents();
        CalculateEventValues();
        UI_Update();
    }

    void GetPlayerPrefsValues()
    {
        gameturn = PlayerPrefs.GetInt("gameturn");
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
        eventSum = bonus - cost;
        Debug.Log($"Event Sum: {eventSum}, Cost: {cost}, Bonus: {bonus}");
        PlayerPrefs.SetInt("EventSum", eventSum);
    }

    void RandomEvents(int RandomEventNumber)
    {
        switch (RandomEventNumber)
        {
            
            case 1: 
                cost = 500;
                RandomEventText.text = "ดูสัตว์พวกนั้นสิช่างน่ารักซะเหลือเกิน โอ๊ย นกกระจอกเทศตัวนี้มันอะไรเนียจิ๊กหัวฉันซะเลือดออกเลย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 2:
                cost = 800;
                RandomEventText.text = "ไม่นะรองเท้าทำงานสุดที่รักของฉันได้สิ้นอายุไขไปแล้ว แบบนี้ต้องเสียเงินซื้อคู่ใหม่อีกนะสิไม่นะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 3:
                cost = 1250;
                RandomEventText.text = "อาหารนั้น เพราะอาหารนั้นแน่เลยทำให้ท้องฉันเป็นแบบนี้ อุ้ย ไม่ไหวแล้ว ขอเข้าห้องน้ำก่อนนะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 4:
                cost = 1850;
                RandomEventText.text = "พี่วินทำกันได้ ระหว่างนั่งมอไซไปทำงานขับรถเกี่ยวชุดไปทำงานขาด โอ้ไม่นะพี่วิน";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 5:
                cost = 2500;
                RandomEventText.text = "หัวหน้าที่ทำงานดันยื่นซองรับบริจากให้เด็กผู้ด้อยโอกาส...ฉันไม่กล้าไม่กล้าปฏิเสธหัวหน้าซะด้วยสิ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 6:
                cost = 2700;
                RandomEventText.text = "น้องแมวแสนรักของฉันมากระซิบข้างหูบอกว่าอยากได้คอนโดใหม่ก็จัดไปเลยสิจ๊ะ ชุดใหญ่ไฟกระพริบ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 7:
                cost = 3500;
                RandomEventText.text = "ฉันไม่ชอบการไปโรงพยาบาลเอาซะเลยแต่ทำไงแต่ฉันดันหกล้มพลาดตกบันไดซะได้";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 8:
                cost = 4800;
                RandomEventText.text = "PM2.5 ช่างอันตรายยิ่งนัก ฉันเป็นคนรักสุขภาพซะด้วยสิซื้อเครื่องฟอกอากาศซักตัวดีกว่า";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 9:
                cost = 5700;
                RandomEventText.text = "หลังจากทำงานหนักพักผ่อนบ้างก็ดีนะ โกทูบาหลี!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 10:
                cost = 8500;
                RandomEventText.text = "เพื่อนที่รักของฉันได้ยืมเงิน แล้วจากนั้นเขาก็หายไปเลยติดต่อไม่ได้ ฉันเป็นห่วงเขาจริงๆเลยนะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 11:
                cost = 9500;
                RandomEventText.text = "ไม่นะ! โน๊ตบุคที่ทำงานประจำพัง ฉันต้องเอาไปซ่อมด่วน เสียเงินอีกแล้วสินะเรา";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 12:
                cost = 12500;
                RandomEventText.text = "มีคนบอกว่าให้เอาเงินไปลงแชร์กับเขาสิ ได้ผลตอบแทน 120% หลังจากฉันจ่ายเงินไปเข้าก็บ็อคเฟสฉันหนีหายไปเลย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 13:
                cost = 15000;
                RandomEventText.text = "เอ๋ไหนในทวิต'ร้าบาล' บอกว่าบ้านฉันปลอดภัยจากน้ำท่วม ไหนตอนนี้ บุ๋มๆๆๆ ... ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 14:
                cost = 17500;
                RandomEventText.text = "ใครบอกว่าฉันทำอาหารไม่เป็น ฉันแค่ลืมปิดแก๊สจนไฟไหม้ครัวเท่านั้นเองแหละ ... ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 15:
                cost = 20000;
                RandomEventText.text = "ทำไมฉันมันขี้ลืมขนาดนี้นะ ลืมล๊อคบ้านหวานโจร ของหายเกือบหมดบ้าน ดีนะที่มันยังเหลือรองเท้าให้ฉัน 1 คู่";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 16:
                cost = 45000;
                RandomEventText.text = "เขาบอกกันว่า โจรขึ้นบ้าน 10 ทีไม่เท่าไฟไหม้ทีเดียวมันเป็นแบบนี้สินะ ไปแล้วบ้านฉันไม่มีประกันซะด้วย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
            
            case 17:
                bonus = 250;
                RandomEventText.text = "หัวหน้าที่ทำงานได้เลื่อนขั่น เลี้ยงหมูกระทะสบายกระเป๋ากินฟรี 1 มื้อ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 18:
                bonus = 500;
                RandomEventText.text = "ระหว่างเดินไปทำงานมีแบงค์ 500 ลอยมาแปะหน้าฉันเฉยเลยอะไรกันเนีย";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 19:
                bonus = 1250;
                RandomEventText.text = "โรงพยาบาล ฉันไม่ชอบที่นี้เลย แต่ฉันก็ดีใจที่มีญาติที่รักมาเยี่ยมแล้วออกค่ารักษาให้บางครั้งก็ได้เงินส่วนเกินมาบ้างนะ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 20:
                bonus = 2500;
                RandomEventText.text = "เพื่อนที่ยืมเงินแล้วหาย อยู่ดีๆก็กลับเอาเงินมาคืนซะงั้น โชคดีๆ";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 21:
                bonus = 3750;
                RandomEventText.text = "ปีนี้ฉันได้เงินภาษีคืน หา! เรื่องจริงใช่ไหมเนีย!";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 22:
                bonus = 7500;
                RandomEventText.text = "เห้ยฉันสมัครคนละเสี้ยวทันได้เงินจาก'ร้าบาล'เยอะเลยว้าว";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 23:
                bonus = 10000;
                RandomEventText.text = "ฉันชอบทำอาหารและดันไปถูกใจพี่ข้างบ้านที่เป็นเชฟ เขาเลยขอซื้อสูตรต่อ สำหรับคนอื่นมันจะอร่อยจริงไหมน้า";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;

            case 24:
                bonus = 25000;
                RandomEventText.text = "ฉันไม่เคยซื้อหวยนะ แต่คุณแม่ดันซื้อแล้วเอามาให้ฉัน อะไรนะใบนั้นมันถูกรางวัลใหญ่หรอไม่จริงน่า";
                Debug.Log("Event Number: " + RandomEventNumber);
                break;
        }
        //return eventNumbers;
    }

    void SpecificEvents()
    {
        switch (gameturn)
        {
            case 1:
                EventText.text = "วุ้วในที่สุกก็ผ่านรอบแรกไปได้ จะออกจากโลกใบนี้ได้ต้อง ผ่าน 4 รู้แบบนี้ไปให้ได้ทุกเทินสินะ ";
                break;

            case 2:
                cost += 150;
                EventText.text = "ยังไม่ค่อยเข้าใจเรื่องราวในโลกนี้สักเท่าไหร่แต่ก็เริ่มจับทางได้แล้วบ้าง มีตู้กดน้ำอยู่แถวนี้ด้วยหรือขอสักขวดละกัน";
                break;
            
            case 3:
                cost += 2500;
                EventText.text = "เยส เริ่มเข้ามือแล้วพอเข้าใจก็ไม่ยากสะเท่าไหร่นิหนา โอ้ย เจ้าหินน้าทำฉันสะดุดสะได้ อ้าเงินฉันปลิวไปหมดแล้ว";
                break;

            case 4:
                EventText.text = "โห ฉันต้องจ่ายหนี้มากมายขนาดนี้เลยหรอเนีย ถึงมันจะหนักหนาสาหัสเท่าไหร่แต่เราต้องผ่านพ้นไปให้ได้";
                break;

            case 5:
                cost += 3000;
                EventText.text = "ระหว่างอยู่ในนี้เห็นกล่องวิเศษด้วยแหละบอกหยอดเงินเข้าไป แล้วจะได้กลับมา 10 เท่า ฉันเลยหยอดไปสะ 3000 แต่ไม่เห็นเกิดอะไรขึ้นเลย";
                break;
            
            case 6:
                cost += 1250;
                EventText.text = "อ่าแบบนี้นิเองโลกแห่งเงินสินะ เงินคือการลงทุน งั้ลฉันลงทุนกับหวยบ้างดีกว่าเพื่อจะถูก 10 ล้าน ... เอ๋อะไรนะฉันไม่ถูกรางวัลหรอซื้อไปตั้งหลายใบ";
                break;
            
            case 7:
                EventText.text = "เทินต่อไปต้องจ่ายหนี้แล้วสินะเอ้า หึ๊บเข้าไว้นะตัวฉัน";
                break;

            case 8:
                EventText.text = "หลังจากจ่ายหนี่ โอ้มเทพเจ้าสิ่งศักสิทลูกขอเงินสัก 1000 ด้วยเทิด ปิ้ว โอ้ยอะไรมาแปะหน้านี้มันเงิน 1000 บาท แต่ เป็นแบงค์กาโม่นิหวา";
                break;

            case 9:
                EventText.text = "เรามาเกินครึ่งทางแล้วสู้ต่อไปนะตัวฉัน";
                break;

            case 10:
                bonus += 2500;
                EventText.text = "เอ๋วันนี้สงใสดวงดีจริง อยู่ดีๆมีนกกระดาษ คาบเงินมาให้เฉยๆเลย 2500 บาท ว้าวนี้มันอะไรกันเนีย";
                break;

            case 11:
                EventText.text = "ใกล้แล้วเทินสุดท้ายแล้วสินะถ้าฉันจ่ายหนี้ก้อนหนี้ได้ฉันก็จะได้หลุดพ้นจากโลกนี้สักที วุ้ว เครียดกินหมูกะทะสักหน่อยละกัน";
                break;
            
            case 12:
                EventText.text = "ใกล้แล้วเทินสุดท้ายแล้วสินะถ้าฉันจ่ายหนี้ก้อนหนี้ได้ฉันก็จะได้หลุดพ้นจากโลกนี้สักที วุ้ว เครียดกินหมูกะทะสักหน่อยละกัน";
                break;
        }
        Debug.Log($"Cost or Bonus: {bonus - cost}");
    }

    void Update()
    {
        
    }

    void UI_Update()
    {
        ValueDisplay.text = eventSum.ToString("N0");
        if (eventSum > 0)
        {
            ValueDisplay.color = new Color (0, 0.65f, 0, 1f);
        }
        else if (eventSum < 0)
        {
            ValueDisplay.color = Color.red;
        }
    }
}
