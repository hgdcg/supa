package ustc.supa;

import java.util.List;

import android.net.wifi.ScanResult;
import android.net.wifi.WifiInfo;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.view.Menu;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity {

    TextView tv;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String wserviceName = Context.WIFI_SERVICE;
        WifiManager wm = (WifiManager) getSystemService(wserviceName);

        WifiInfo info = wm.getConnectionInfo();
        int strength = info.getRssi();
        int speed = info.getLinkSpeed();
        String units = WifiInfo.LINK_SPEED_UNITS;
        String ssid = info.getSSID();

        tv  = (TextView) findViewById(R.id.textView1);

        List<ScanResult> results = wm.getScanResults();
        String otherwifi = "The existing network is: \n\n";

        for (ScanResult result : results) {
            otherwifi += result.SSID  + ":" + result.level + "\n";
        }

        String text = "We are connecting to " + ssid + " at " + String.valueOf(speed) + "   " + String.valueOf(units) + ". Strength : " + strength;
        otherwifi += "\n\n";
        otherwifi += text;

        tv.setText(otherwifi);

    }


    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

}

