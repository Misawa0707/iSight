using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    //  変数の宣言
    string CollisionName;           //  衝突相手の名前
    bool RayHit;                    //  レイが当たっているかどうか
    public float Battery;           //  バッテリー
    GameObject player;              //  プレイヤーオブジェクト
    ChangeCamera changeCamera;      //  カメラ切り替えスクリプト

	// Use this for initialization
	void Start () {
        //  変数の初期化処理
        RayHit = false;
        Battery = 1.0f;
        player = GameObject.Find("Player");
        changeCamera = player.GetComponent<ChangeCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //  マウスの左クリックが離されたら
        if (Input.GetMouseButtonUp(0))
        {
            if (this.gameObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(this.GetComponent<FixedJoint>());
            }

            //  オブジェクトのnulチェック
            if (transform.Find(CollisionName) != null)
            {
                 transform.Find(CollisionName).parent = null;
            }
        }

        //  レイを飛ばす処理
        Ray();
        //  子オブジェクトとの距離が離れたら親子関係離す
        DistanceObject();

        //  カメラ使用時にバッテリーを減らす
        if(changeCamera.GetCameraFlag())
        {
            //  バッテリーが0以上なら
            if (Battery > 0)
            {
                Battery -= 0.0001f;
            }
        }

        //  FPSの表示(デバッグ用)
        //float fps = 1.0f / Time.deltaTime;
        //Debug.LogFormat("{0}fps", fps);
    }

    //  衝突が行われていたら
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //  動かすことのできるものだったら
        if (hit.gameObject.tag == "MoveBox")
        {
            Carry(hit);
        }
        
    }

    //  運ぶ処理
    void Carry(ControllerColliderHit hit)
    {
        //  マウスの左クリックが押されていたら
        if (Input.GetMouseButton(0) && RayHit == true)
        {
            if (this.gameObject.GetComponent<FixedJoint>() == null)
            {
                this.gameObject.AddComponent<FixedJoint>();
                this.GetComponent<FixedJoint>().connectedBody = hit.gameObject.GetComponent<Rigidbody>();
                hit.transform.parent = this.transform;
                this.GetComponent<FixedJoint>().enableCollision = true;
            }


            CollisionName = hit.gameObject.name;
        }

    }

    //  プレイヤーの正面にレイを飛ばす
    void Ray()
    {
        // 自身の向きベクトル取得
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2);

        Ray ray = Camera.main.ScreenPointToRay(center);

        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, 5.0f))
        {
            // hit.point が正面方向へRayをとばした際の接触座標.
            if (hit.collider.tag == "MoveBox")
            {
                RayHit = true;
            }
            else
            {
                RayHit = false;
            }
        }
        else
        {
            RayHit = false;
        }

        //Rayの飛ばせる距離
        int distance = 5;

        //Rayの可視化   ↓Rayの原点　　　　↓Rayの方向　　　↓Rayの色
        Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);
    }


    //  距離に応じて親子関係を離す
    void DistanceObject()
    {
        //  オブジェクトのnullチェック
        if (transform.Find(CollisionName) != null)
        {
            //  子オブジェクトの現在座標
            Vector3 posChild = transform.Find(CollisionName).transform.position;
            //  プレイヤーの現在座標
            Vector3 posPlayer = transform.position;
            //  二つのオブジェクトの距離
            float dis = Vector3.Distance(posPlayer, posChild);

            //  距離が一定以上なら親子関係を離す
            if(dis >= 3.0f)
            {
                //transform.Find(CollisionName).parent = null;
                //Destroy(this.GetComponent<FixedJoint>());
            }

        }
       
    }

}
