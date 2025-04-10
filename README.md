Feito por: Gabriel Gaudí Pozzi Rosalvo

<blockquote>
<p>Written with <a href="https://stackedit.io/">StackEdit</a>.</p>
</blockquote>
<h2 id="atividade-raycast-1104">Atividade Raycast 11/04</h2>
<p>Processo de Desenvolvimento:</p>
<ol>
<li>Organização e preparação<br>
Após a cena ser criada, foram adicionadas pastas para os scripts, materiais, prefabs e prints para documentação dentro de <em>Assets</em>. Na cena, foi criado um objeto contendo um <em>CharacterController</em> e a câmera para o jogador, e um plano para o chão.<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/AssetsTab0.1.png" alt="AssetsTab0.1"><br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/Scene&amp;objects0.1.png?raw=true" alt="Scene&amp;Objects"></li>
<li>Scripts básicos</li>
</ol>
<ul>
<li>
<p>PlayerMovement.cs: para movimentação do jogador pelo mapa<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/ScriptMovement2.1.png?raw=true" alt="Movement.cs"><br>
Variáveis:</p>
<ul>
<li><strong>speed;</strong> Variável float que determina o quão rápido o jogador vai se movimentar.</li>
<li><strong>playerController;</strong> contém o componente <em>CharacterController</em> do objeto do jogador.</li>
<li><strong>movX e movZ;</strong> usadas para armazenar a entrada do jogador nas teclas de movimento (WASD e as setas).</li>
<li><strong>playerMovement;</strong> Vetor cujo valor é a junção da posição do jogador no eixo X (transform.right) com a entrada de movimento. O mesmo vale para o eixo Z (transform.forward).</li>
</ul>
<p>Métodos:</p>
<ul>
<li><strong>FixedUpdate();</strong> é usado ao invés do Update pois se mantém consistente não importa a velocidade da máquina.</li>
<li><strong>Input.GetAxis(“Horizontal”, “Vertical”)</strong> retorna certos valores quando o jogador pressiona as teclas de movimento.</li>
<li><strong>playerController.Move();</strong> move o <em>CharacterController</em> do objeto do jogador e o objeto em si, baseado na tecla apertada e a posição atual, relativamente à velocidade (variável <strong>speed</strong>).</li>
</ul>
</li>
<li>
<p>CameraControl.cs: para movimentação da câmera com o mouse e a rotação do jogador de acordo com ela.<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/ScriptCamera2.2.png?raw=true" alt="Camera"><br>
Variáveis:</p>
<ul>
<li><strong>lookSpeed;</strong> float que controla o quão rápido a câmera vai se mover com o movimento do mouse.</li>
<li><strong>cameraVertical;</strong> subtraído do movimento do mouse, retorna um valor igual a rotação que a câmera deve sofrer.</li>
<li><strong>playerTransform;</strong> o componente <em>Transform</em> do objeto do jogador.</li>
<li><strong>mouseX, mouseY;</strong> armazenam o movimento do mouse com sua direção, proporcionalmente ao valor da velocidade.</li>
</ul>
<p>Métodos:</p>
<ul>
<li><strong>Start();</strong> ao iniciar o jogo, deixa o cursor invisível e travado no centro da tela, com <em><strong>CursorLockMode.Locked</strong></em>.</li>
<li>**Input.GetAxis(“Mouse X”, "Mouse Y); ** retorna valores baseado nos movimentos do mouse.</li>
<li><strong>Mathf.Clamp(cameraVertical, -90, 90);</strong> impede que a rotação da câmera seja menor que -90 (jogador olhando para o chão) ou maior que 90 (olhando para cima).</li>
<li><strong>Quaternion.Euler(cameraVertical, 0, 0);</strong> transforma os três valores em uma variável para rotação. Seu valor é atribuído a <em>transform.localRotation</em>, rotacionando a câmera verticalmente.</li>
<li><strong>playerTransform.Rotate(Vector3.up * mouseX);</strong> rotaciona o jogador no eixo Y (Vector3.up) de acordo com o movimento horizontal do mouse. Como a câmera está contida nele, ela é rotacionada também.</li>
</ul>
</li>
</ul>
<ol start="3">
<li>Script com Raycast (movimentação de objeto com a câmera)<br>
GravityGun.cs<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/Script3.1.png?raw=true" alt="Rayscript"></li>
</ol>
<ul>
<li>
<p>Atributos</p>
<ul>
<li><strong>looking;</strong> <em>Transform</em> de um objeto que é filho do objeto jogador, seguindo sua posição e rotação.</li>
<li><strong>interactions;</strong> referência à <em>LayerMask</em>, ou camada dos objetos que podem ser movidos.</li>
<li><strong>ray;</strong> variável do tipo <em>RaycastHit</em>, recebe e armazena informações do objeto acertado pelo Raycast.</li>
<li><strong>ray.transform.position;</strong> define a posição do objeto acertado pelo Raycast como a posição do objeto vazio à frente da câmera (<strong>looking.transform.position</strong>).</li>
</ul>
</li>
<li>
<p>Métodos</p>
</li>
<li>
<p><strong>LayerMask.GetMask(“Movable”)</strong> busca por uma camada com o nome “Movable” e coloca uma referência à ela na variável <strong>interactions</strong>.</p>
<ul>
<li><strong>Physics.Raycast(transform.position, transform.forward, out RaycastHit ray, 30f, interactions)</strong> cria um raio (linha reta), partindo da posição da câmera (<em>transform.position</em>); indo para onde o jogador/câmera estão olhando (<em>transform.forward</em>); com um tamanho/alcance de 30; onde as informações do objeto colidido ficarão na variável <em>ray</em> e apenas colidirá com objetos da camada <em>interactions</em>.</li>
<li><strong>Input.GetMouseButton(1)</strong> retorna <em>true</em> se o botão direito do mouse (representado pelo “1”) for pressionado. Ao clicar com o mouse, se o Raycast detectar um objeto, a condicional será verdadeira.</li>
</ul>
</li>
</ul>
<ol start="4">
<li>Alterações na cena para o Raycast</li>
</ol>
<ul>
<li>Adição de cubos com rigidbody para o jogador movimentar;</li>
<li>Criação de um material para dar destaque aos cubos;</li>
<li>Criação de um material para deixar o chão menos escuro;<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/CubeRigidBody4.12.png?raw=true" alt="CubeRB"><br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/Cubes&amp;Materials4.1.png?raw=true" alt="CM"></li>
<li>Camada nova para os objetos que vão interagir com o Raycast.<br>
(imagem)<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/LayerCreate4.2.png?raw=true" alt="Layer"></li>
<li>Objeto vazio cuja posição será a do objeto que for segurado pelo jogador<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/EmptyObjCreation4.3.png?raw=true" alt="Empty"></li>
</ul>
<ol start="5">
<li>Implementação de Prefabs</li>
</ol>
<ul>
<li>Adicionar gameObject para o prefab<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/ObjectsForPrefabs5.1.png?raw=true" alt="ObjPrefab"></li>
<li>Criar os materias que serão usados pelos prefabs<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/MaterialsForPrefabs5.21.png?raw=true" alt="MtPrefab"></li>
<li>Transfomar o objeto em prefab<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/GameObjectToPrefab5.3.png?raw=true" alt="CreatePrefab"></li>
<li>Criação</li>
<li>Alterações no script para usar os prefabs<br>
<img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/ScriptPrefabs5.5.png?raw=true" alt="AtributosPrefabs"><br>
Atributos:
<ul>
<li><strong>canShoot;</strong> boolean, diz se o prefab pode ser atirado ou não.</li>
<li><strong>portals;</strong> array contendo os dois prefabs criados.</li>
<li><strong>portalNumber;</strong> número correspondente à qual dos prefabs será usado.</li>
<li><strong>destroyPortals;</strong> array de GameObjects que vão ser removidos.</li>
</ul>
</li>
</ul>
<p><img src="https://github.com/GabrielGaudi/AulaRayCast/blob/main/Imagens/PortalCreateScript5.6.png?raw=true" alt="Metodos"><br>
Métodos:</p>
<ul>
<li><strong>Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 50f);</strong> cria outro Raycast, similar ao outro, mas com alcance maior e afetando todas as camadas.</li>
<li><strong>Input.GetMouseButton(0);</strong> verifica se o botão esquerdo do mouse (identificado pelo 0) está sendo pressionado. Aqui, a condição verifica se o Raycast acerta algo, se o botão esquerdo for pressionado e se <em>canShoot</em> é verdadeiro, ou seja, se o jogador pode atirar.</li>
<li><strong>CreatePortal();</strong> este método coloca a variável <em>canShoot</em> como falsa, impedindo que o jogador atire muitas vezes seguidas. Então, caso o valor de <em>portalNumber</em> passe de 1, ou seja, não corresponda a nenhum dos prefabs, o retorna para 0.</li>
<li><strong>GameObject.FindGameObjectsWithTag(“Portal”);</strong> Busca por todos os objetos com a <em>Tag</em>: <em>“Portal”</em> e os junta no array <em>destroyPortals</em>.</li>
<li><strong>Destroy(oneObject);</strong> para cada <em>GameObject</em> contido no array <em>destroyPortals</em>, um deles é destruído, ou seja destrói uma quantidade de objetos correspondente a quantos estãoo no array, removendo todos eles.</li>
<li><strong>StartCoroutine(nameof(PortalCooldown));</strong> inicia um bloco de código que corre separadamente do resto (nomeado “PortalCooldown”) , então pode ser executado simultaneamente.</li>
<li><strong>yield return new WaitForSeconds(2);</strong> pausa a execução do código até que receba algum retorno, que nesse caso é dado pelo método <em>WaitForSeconds</em> após 2 segundos. Após isso, o jogador pode atacar denovo e o código retorna à execução normal.</li>
</ul>
<ol start="6">
  
<li>Vídeo da gameplay</li>


https://github.com/user-attachments/assets/b964c8a0-51f2-4d65-8961-0896aa7f10e8


<li>Relatório da dupla</li>
Gabriel Gaudí Pozzi Rosalvo: fez tudinho
</ol>

