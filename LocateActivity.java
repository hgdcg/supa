package ustc.supa;

import java.util.List;
import java.lang.Math;

import android.net.wifi.ScanResult;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.widget.TextView;

public class LocateActivity extends Activity {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_locate);

        String wserviceName = Context.WIFI_SERVICE;
        WifiManager wm = (WifiManager) getSystemService(wserviceName);

        TextView tv = (TextView) findViewById(R.id.textView1);

        List<ScanResult> results = wm.getScanResults();
        String otherwifi = "The existing network is: \n\n";

        for (ScanResult result : results) {
            if (!result.SSID.equals("")) {
                otherwifi += result.SSID + ":" + result.level + "\n";
                otherwifi += "Frequency: " + result.frequency + "\n";
                otherwifi += "Distance: " + GetDistance(result.level, result.frequency) + "\n";
            }
            otherwifi += "\n";
        }

        otherwifi += "\n\n";

        tv.setText(otherwifi);
    }

    // Here we assume the transmitting power of APs are 50mW.
    private double DBmToW(int dbm) {
        dbm -= 30;
        double temp = (double) dbm / 10;
        return Math.pow(10, temp);
    }

    private double GetDistance(int dbm, int frequency) {
        double Pr = DBmToW(dbm);
        return 1.34 / Math.sqrt(Pr) / frequency;
    }
}

