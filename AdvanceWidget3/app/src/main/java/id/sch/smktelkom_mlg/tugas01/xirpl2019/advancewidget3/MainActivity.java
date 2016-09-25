package id.sch.smktelkom_mlg.tugas01.xirpl2019.advancewidget3;

import android.app.Activity;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity {
    String nama;
    ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

       binding = DataBindingUtil.setContentView(R.layout.activity_main);
        binding.setNama(nama);
    }
}
